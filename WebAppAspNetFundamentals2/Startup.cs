using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Repo;
using WebAppAspNetFundamentals2.Models.Service;

namespace WebAppAspNetFundamentals2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
              
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //------------------------- connection to database -----------------------------------------
            services.AddDbContext<PeopleDbContext>(options => options.
            UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Identity
            services.AddIdentity<ClassUser, IdentityRole>()
                    .AddEntityFrameworkStores<PeopleDbContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            //------------------------- services IoC ---------------------------------------------------
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPersonLanguageService, PersonLanguageService>();

            //------------------------- repo IoC -------------------------------------------------------
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ILanguageRepo, LanguageRepo>();
            services.AddScoped<IPersonLanguageRepo, PersonLanguageRepo>();

            //-------------------------CORS----------------------

            services.AddCors(options =>
                {
                    options.AddPolicy("ReactPolicy",
                        builder =>
                        {
                            builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        });
                });

            //----------------Sawgger------------

            services.AddSwaggerGen();

            //services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "People  API V1");
            });

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();// Add this for login
            app.UseAuthorization();// Add this for rights to do it

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

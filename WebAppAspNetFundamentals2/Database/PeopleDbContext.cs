﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Database
{
    public class PeopleDbContext : IdentityDbContext<ClassUser>
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            //Recommend on the first line inside method.

            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
            new {
                pl.PersonId,
                pl.LanguageId
            });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(pl => pl.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);
        }

        public DbSet<Person> People { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        //public DbSet<ClassUser> ClassUsers { get; set; }
        //security risk

    }
}

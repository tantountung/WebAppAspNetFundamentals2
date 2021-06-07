using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppAspNetFundamentals2.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguangeName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_City",
                table: "People",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_People_Country",
                table: "People",
                column: "Country");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_City",
                table: "People",
                column: "City",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Countries_Country",
                table: "People",
                column: "Country",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_City",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Countries_Country",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_City",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_Country",
                table: "People");

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LanguangeName",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

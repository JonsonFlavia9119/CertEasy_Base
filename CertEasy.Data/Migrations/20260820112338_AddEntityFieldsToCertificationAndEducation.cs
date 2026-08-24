using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class AddEntityFieldsToCertificationAndEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntityID",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityTypeID",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityID",
                table: "Certifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityTypeID",
                table: "Certifications",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityID",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EntityTypeID",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EntityID",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "EntityTypeID",
                table: "Certifications");
        }
    }
}
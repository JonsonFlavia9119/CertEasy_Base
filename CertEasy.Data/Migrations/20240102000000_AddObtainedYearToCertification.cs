using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class AddObtainedYearToCertification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObtainedYear",
                table: "Certifications",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObtainedYear",
                table: "Certifications");
        }
    }
}
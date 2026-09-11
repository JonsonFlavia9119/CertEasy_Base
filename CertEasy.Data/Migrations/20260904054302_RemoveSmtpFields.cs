using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class RemoveSmtpFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmtpPassword",
                table: "EmailConfigurations");

            migrationBuilder.DropColumn(
                name: "SmtpPort",
                table: "EmailConfigurations");

            migrationBuilder.DropColumn(
                name: "SmtpServer",
                table: "EmailConfigurations");

            migrationBuilder.DropColumn(
                name: "SmtpUsername",
                table: "EmailConfigurations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmtpPassword",
                table: "EmailConfigurations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SmtpPort",
                table: "EmailConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SmtpServer",
                table: "EmailConfigurations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SmtpUsername",
                table: "EmailConfigurations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
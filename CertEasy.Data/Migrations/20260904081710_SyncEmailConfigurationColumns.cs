using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class SyncEmailConfigurationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "EmailConfigurations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "EmailConfigurations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "EmailConfigurations");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "EmailConfigurations");
        }
    }
}
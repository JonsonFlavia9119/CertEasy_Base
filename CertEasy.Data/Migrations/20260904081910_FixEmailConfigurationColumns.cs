using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class FixEmailConfigurationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (!migrationBuilder.ActiveProvider.Contains("SqlServer")) return;

            // Check and add ProviderName if missing
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns 
                               WHERE object_id = OBJECT_ID(N'[dbo].[EmailConfigurations]') 
                               AND name = 'ProviderName')
                BEGIN
                    ALTER TABLE [EmailConfigurations] ADD [ProviderName] nvarchar(255) NOT NULL DEFAULT '';
                END
            ");

            // Check and add ApiKey if missing
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns 
                               WHERE object_id = OBJECT_ID(N'[dbo].[EmailConfigurations]') 
                               AND name = 'ApiKey')
                BEGIN
                    ALTER TABLE [EmailConfigurations] ADD [ApiKey] nvarchar(500) NULL;
                END
            ");
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

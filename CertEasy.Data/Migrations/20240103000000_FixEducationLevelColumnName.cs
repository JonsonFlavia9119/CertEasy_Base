using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class FixEducationLevelColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Root Cause Fix: The previous migration failed because 'InstituteName' didn't exist when AlterColumn was called.
            // We check for column existence and add it if missing before attempting alterations.
            
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns 
                               WHERE object_id = OBJECT_ID(N'[dbo].[EducationLevels]') 
                               AND name = 'InstituteName')
                BEGIN
                    ALTER TABLE [EducationLevels] ADD [InstituteName] nvarchar(max) NULL;
                END
            ");

            migrationBuilder.AlterColumn<string>(
                name: "InstituteName",
                table: "EducationLevels",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstituteName",
                table: "EducationLevels");
        }
    }
}
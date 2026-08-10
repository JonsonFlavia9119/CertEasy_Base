using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class FixEducationLevelStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Final validation: Ensure 'InstituteName' is correctly typed and named.
            // This migration acts as a catch-all safety net for the schema.
            
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns 
                               WHERE object_id = OBJECT_ID(N'[dbo].[EducationLevels]') 
                               AND name = 'InstituteName')
                BEGIN
                    ALTER TABLE [EducationLevels] ADD [InstituteName] nvarchar(200) NULL;
                END
                ELSE
                BEGIN
                    -- Ensure length is correct if it exists but was wrong
                    ALTER TABLE [EducationLevels] ALTER COLUMN [InstituteName] nvarchar(200) NULL;
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
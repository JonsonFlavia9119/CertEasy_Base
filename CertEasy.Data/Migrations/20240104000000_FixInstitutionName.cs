using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class FixInstitutionName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Unify naming: Since the model uses 'InstituteName', we ensure consistency.
            // If 'InstitutionName' was accidentally created, we merge it back or just ensure InstituteName is populated.
            
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.columns 
                           WHERE object_id = OBJECT_ID(N'[dbo].[EducationLevels]') 
                           AND name = 'InstitutionName')
                BEGIN
                    UPDATE EducationLevels SET InstituteName = InstitutionName WHERE InstituteName IS NULL;
                    ALTER TABLE EducationLevels DROP COLUMN InstitutionName;
                END
            ");

            // Data migration for existing seeded data using correct column name
            migrationBuilder.Sql("UPDATE EducationLevels SET InstituteName = 'Global University' WHERE Id = 1 AND InstituteName IS NULL");
            migrationBuilder.Sql("UPDATE EducationLevels SET InstituteName = 'International Institute' WHERE Id = 2 AND InstituteName IS NULL");
            migrationBuilder.Sql("UPDATE EducationLevels SET InstituteName = 'Research Academy' WHERE Id = 3 AND InstituteName IS NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No-op to avoid breaking the forward-only fix
        }
    }
}
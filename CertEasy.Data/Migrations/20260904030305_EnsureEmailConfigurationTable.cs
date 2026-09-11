using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class EnsureEmailConfigurationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EmailConfigurations')
                BEGIN
                    CREATE TABLE [EmailConfigurations] (
                        [Id] int NOT NULL IDENTITY,
                        [SmtpServer] nvarchar(255) NOT NULL,
                        [SmtpPort] int NOT NULL,
                        [SenderEmail] nvarchar(255) NOT NULL,
                        [SenderName] nvarchar(255) NOT NULL,
                        [SmtpUsername] nvarchar(255) NULL,
                        [SmtpPassword] nvarchar(255) NULL,
                        [EnableSsl] bit NOT NULL,
                        [CreatedDate] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
                        [CreatedBy] nvarchar(100) NOT NULL,
                        [UpdatedDate] datetime2 NULL,
                        [UpdatedBy] nvarchar(100) NULL,
                        CONSTRAINT [PK_EmailConfigurations] PRIMARY KEY ([Id])
                    );
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "EmailConfigurations");
        }
    }
}

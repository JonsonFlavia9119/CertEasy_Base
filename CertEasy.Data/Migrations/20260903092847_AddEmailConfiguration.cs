using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class AddEmailConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmtpServer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SmtpPort = table.Column<int>(type: "int", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SmtpUsername = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SmtpPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EnableSsl = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfigurations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailConfigurations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EnableSsl", "SenderEmail", "SenderName", "SmtpPassword", "SmtpPort", "SmtpServer", "SmtpUsername", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "noreply@certeasy.local", "CertEasy Notifications", null, 25, "localhost", null, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailConfigurations");
        }
    }
}
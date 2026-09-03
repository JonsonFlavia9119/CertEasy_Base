using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class AddExamsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExamCenter = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExamSlot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "ExamID",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ExamID",
                table: "Applications",
                column: "ExamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Exams_ExamID",
                table: "Applications",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "Id");

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ExamCenter", "ExamName", "ExamSlot", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "New York Testing Center", "Spring 2024 Exam Session", new DateTime(2024, 4, 15, 10, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ExamCenter", "ExamName", "ExamSlot", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chicago Testing Center", "Spring 2024 Exam Session", new DateTime(2024, 4, 16, 14, 0, 0, 0, DateTimeKind.Utc), "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Exams_ExamID",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ExamID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ExamID",
                table: "Applications");
        }
    }
}

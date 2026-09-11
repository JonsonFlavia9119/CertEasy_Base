using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class SeedStatusesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "StatusName", "UpdatedBy", "UpdatedDate" },
                values: new object[,] {
                    { 1, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User Profile", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Certification Selection", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational Qualification", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejection", "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 8; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Statuses",
                    keyColumn: "Id",
                    keyValue: i);
            }
        }
    }
}

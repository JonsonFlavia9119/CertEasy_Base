using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace CertEasy.Data.Migrations
{
    public partial class AddBadgeFieldsToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BadgeId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BadgeName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BadgeAssignedDate",
                table: "Applications",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BadgeName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BadgeAssignedDate",
                table: "Applications");
        }
    }
}

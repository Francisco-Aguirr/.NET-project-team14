using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessCategoryAndRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntrepreneurRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrepreneurRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCategories");

            migrationBuilder.DropTable(
                name: "EntrepreneurRequests");
        }
    }
}

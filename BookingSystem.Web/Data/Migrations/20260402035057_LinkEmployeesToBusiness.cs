using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class LinkEmployeesToBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BusinessId",
                table: "Employees",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Businesses_BusinessId",
                table: "Employees",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Businesses_BusinessId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BusinessId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Employees");
        }
    }
}

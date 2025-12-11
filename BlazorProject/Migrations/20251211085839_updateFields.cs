using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations
{
    /// <inheritdoc />
    public partial class updateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "Employees",
                newName: "ROLE");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employees",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ROLE",
                table: "Employees",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employees",
                newName: "Id");
        }
    }
}

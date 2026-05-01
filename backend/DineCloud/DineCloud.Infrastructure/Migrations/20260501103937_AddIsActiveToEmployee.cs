using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DineCloud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employee");
        }
    }
}

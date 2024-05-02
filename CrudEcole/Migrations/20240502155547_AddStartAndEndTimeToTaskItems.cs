using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEcole.Migrations
{
    /// <inheritdoc />
    public partial class AddStartAndEndTimeToTaskItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TaskItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TaskItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TaskItems");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class addHourMinute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minute",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Minute",
                table: "Messages");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime2",
                nullable: true);
        }
    }
}

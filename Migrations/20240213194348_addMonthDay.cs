using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class addMonthDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Messages");
        }
    }
}

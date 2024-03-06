using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class addUserIp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIp",
                table: "Users");
        }
    }
}

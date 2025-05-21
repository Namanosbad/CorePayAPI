using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorePayAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");
        }
    }
}

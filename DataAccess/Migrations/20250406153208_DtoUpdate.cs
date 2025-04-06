using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DtoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Parents",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Parents",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Parents",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Parents",
                newName: "email");
        }
    }
}

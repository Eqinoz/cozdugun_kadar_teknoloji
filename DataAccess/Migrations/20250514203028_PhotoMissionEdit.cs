using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PhotoMissionEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasTimeLimit",
                table: "PhotoVerificationMissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MissionDuration",
                table: "PhotoVerificationMissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MissionTitle",
                table: "PhotoVerificationMissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SessionDuration",
                table: "PhotoVerificationMissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTimeLimit",
                table: "PhotoVerificationMissions");

            migrationBuilder.DropColumn(
                name: "MissionDuration",
                table: "PhotoVerificationMissions");

            migrationBuilder.DropColumn(
                name: "MissionTitle",
                table: "PhotoVerificationMissions");

            migrationBuilder.DropColumn(
                name: "SessionDuration",
                table: "PhotoVerificationMissions");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class soonDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AllowedTime",
                table: "QuestionSolvingMissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "SessionDuration",
                table: "PhotoVerificationCompletionMissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsageTime",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UseAuthorization",
                table: "Children",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionDuration",
                table: "PhotoVerificationCompletionMissions");

            migrationBuilder.DropColumn(
                name: "UsageTime",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "UseAuthorization",
                table: "Children");

            migrationBuilder.AlterColumn<long>(
                name: "AllowedTime",
                table: "QuestionSolvingMissions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

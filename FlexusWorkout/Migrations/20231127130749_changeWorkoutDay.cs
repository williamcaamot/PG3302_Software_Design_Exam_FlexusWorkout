using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexusWorkout.Migrations
{
    /// <inheritdoc />
    public partial class changeWorkoutDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDay_User_UserId",
                table: "WorkoutDay");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkoutDay",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDay_User_UserId",
                table: "WorkoutDay",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDay_User_UserId",
                table: "WorkoutDay");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkoutDay",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDay_User_UserId",
                table: "WorkoutDay",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}

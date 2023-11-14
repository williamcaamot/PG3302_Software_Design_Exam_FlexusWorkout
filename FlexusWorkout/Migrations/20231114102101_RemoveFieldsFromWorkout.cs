using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexusWorkout.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFieldsFromWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Workout");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Workout",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Workout",
                type: "longtext",
                nullable: false);
        }
    }
}

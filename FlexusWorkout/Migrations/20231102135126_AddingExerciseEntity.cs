using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexusWorkout.View.Menu.Migrations
{
    /// <inheritdoc />
    public partial class AddingExerciseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Exercise",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercise",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Exercise",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipmentRequired",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntensityLevel",
                table: "Exercise",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Exercise",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Exercise",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Exercise",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "EquipmentRequired",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "IntensityLevel",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exercise",
                newName: "name");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

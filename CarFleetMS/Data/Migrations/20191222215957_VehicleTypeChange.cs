using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class VehicleTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaxNetPowerOfTheEngine",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "MaxAxleLoad",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "EngineCapacity",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxNetPowerOfTheEngine",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "MaxAxleLoad",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "EngineCapacity",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

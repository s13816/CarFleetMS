using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class FuelTypeFieldDeletedColumnFuelTypeCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "FuelTypeId",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    FuelTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.FuelTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FuelTypeId",
                table: "Vehicle",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "Vehicle_FuelType",
                table: "Vehicle",
                column: "FuelTypeId",
                principalTable: "FuelType",
                principalColumn: "FuelTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Vehicle_FuelType",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_FuelTypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicle",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

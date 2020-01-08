using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class VehicleChangesPurposeCardNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Vehicle_Model",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelId);
                    table.ForeignKey(
                        name: "Model_Brand",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                table: "Model",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "Vehicle_Model",
                table: "Vehicle",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Vehicle_Model",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Purpose",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelId);
                    table.ForeignKey(
                        name: "Model_Brand",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                table: "Model",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "Vehicle_Model",
                table: "Vehicle",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

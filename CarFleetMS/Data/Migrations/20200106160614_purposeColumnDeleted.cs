using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class PurposeColumnDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Vehicle_Purpose",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_PurposeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "PurposeId",
                table: "Vehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurposeId",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    PurposeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.PurposeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PurposeId",
                table: "Vehicle",
                column: "PurposeId");

            migrationBuilder.AddForeignKey(
                name: "Vehicle_Purpose",
                table: "Vehicle",
                column: "PurposeId",
                principalTable: "Purpose",
                principalColumn: "PurposeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class InstitutionTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.InstitutionId);
                    table.ForeignKey(
                        name: "FK_Institution_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_InstitutionId",
                table: "Address",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_AddressId",
                table: "Institution",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Institution_InstitutionId",
                table: "Address",
                column: "InstitutionId",
                principalTable: "Institution",
                principalColumn: "InstitutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Institution_InstitutionId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_Address_InstitutionId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Address");
        }
    }
}

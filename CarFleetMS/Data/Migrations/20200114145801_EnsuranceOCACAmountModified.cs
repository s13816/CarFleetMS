using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class EnsuranceOCACAmountModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Ensurance",
                newName: "OCAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "ACAmount",
                table: "Ensurance",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACAmount",
                table: "Ensurance");

            migrationBuilder.RenameColumn(
                name: "OCAmount",
                table: "Ensurance",
                newName: "Amount");
        }
    }
}

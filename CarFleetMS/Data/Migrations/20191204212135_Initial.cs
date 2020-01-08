using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategory",
                columns: table => new
                {
                    VehicleCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategory", x => x.VehicleCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PersonCompany",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PESEL = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    REGON = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsPerson = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCompany", x => x.PersonId);
                    table.ForeignKey(
                        name: "Person_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Models",
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

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                    table.ForeignKey(
                        name: "Driver_Person_Company",
                        column: x => x.PersonCompanyId,
                        principalTable: "PersonCompany",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(maxLength: 12, nullable: false),
                    DateOfFirstRegistration = table.Column<DateTime>(type: "date", nullable: false),
                    Type = table.Column<int>(nullable: true),
                    VIN = table.Column<string>(maxLength: 17, nullable: false),
                    MaxVehicleMass = table.Column<int>(nullable: false),
                    PermissibleGrossVehicleWeight = table.Column<int>(nullable: false),
                    PermissibleTotalWeightOfTheVehicleCombination = table.Column<int>(nullable: false),
                    VehicleMass = table.Column<int>(nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    RegistrationReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    VehicleTypeApprovalCertificateNumber = table.Column<string>(maxLength: 20, nullable: true),
                    AxlesNumber = table.Column<int>(nullable: false),
                    MaxTrailerWeightWithBrake = table.Column<int>(nullable: false),
                    MaxTrailerWeightWithoutBrake = table.Column<int>(nullable: false),
                    EngineCapacity = table.Column<int>(nullable: false),
                    MaxNetPowerOfTheEngine = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(maxLength: 50, nullable: false),
                    PowerToWeightRatio = table.Column<int>(nullable: false),
                    SeatsNumber = table.Column<int>(nullable: false),
                    StandingPositionsNumber = table.Column<int>(nullable: true),
                    Purpose = table.Column<int>(nullable: false),
                    YearOfProduction = table.Column<int>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    MaxAxleLoad = table.Column<int>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    HolderId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    VehicleCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "VehicleOwner",
                        column: x => x.HolderId,
                        principalTable: "PersonCompany",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehicle_Model",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VehicleHolder",
                        column: x => x.OwnerId,
                        principalTable: "PersonCompany",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehicle_VehicleCategory",
                        column: x => x.VehicleCategoryId,
                        principalTable: "VehicleCategory",
                        principalColumn: "VehicleCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehicle_VehicleType",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ensurance",
                columns: table => new
                {
                    EnsuranceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnsuranceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    NameOfTheCompany = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    PersonCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensurance", x => x.EnsuranceId);
                    table.ForeignKey(
                        name: "Ensurance_Person_Company",
                        column: x => x.PersonCompanyId,
                        principalTable: "PersonCompany",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VehicleEnsurance_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    FuelInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.FuelInvoiceId);
                    table.ForeignKey(
                        name: "FuelInvoice_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repair",
                columns: table => new
                {
                    RepairId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Note = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repair", x => x.RepairId);
                    table.ForeignKey(
                        name: "Repair_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalExamination",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfExam = table.Column<DateTime>(type: "date", nullable: false),
                    Validity = table.Column<DateTime>(type: "date", nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalExamination", x => x.ServiceId);
                    table.ForeignKey(
                        name: "Service_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Driver",
                columns: table => new
                {
                    VehicleDriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Driver", x => x.VehicleDriverId);
                    table.ForeignKey(
                        name: "Vehicle_Driver_Driver",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehicle_Driver_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAnnotations",
                columns: table => new
                {
                    VehicleAnnotationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAnnotations", x => x.VehicleAnnotationId);
                    table.ForeignKey(
                        name: "AdditionalVehicleInfo_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_PersonCompanyId",
                table: "Driver",
                column: "PersonCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensurance_PersonCompanyId",
                table: "Ensurance",
                column: "PersonCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensurance_VehicleId",
                table: "Ensurance",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VehicleId",
                table: "Invoice",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCompany_AddressId",
                table: "PersonCompany",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Repair_VehicleId",
                table: "Repair",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExamination_VehicleId",
                table: "TechnicalExamination",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_HolderId",
                table: "Vehicle",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicle",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_OwnerId",
                table: "Vehicle",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleCategoryId",
                table: "Vehicle",
                column: "VehicleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Driver_DriverId",
                table: "Vehicle_Driver",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Driver_VehicleId",
                table: "Vehicle_Driver",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAnnotations_VehicleId",
                table: "VehicleAnnotations",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ensurance");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Repair");

            migrationBuilder.DropTable(
                name: "TechnicalExamination");

            migrationBuilder.DropTable(
                name: "Vehicle_Driver");

            migrationBuilder.DropTable(
                name: "VehicleAnnotations");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "PersonCompany");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "VehicleCategory");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}

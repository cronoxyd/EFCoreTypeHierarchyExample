using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTypeHierarchyExample.Common.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerCount = table.Column<int>(type: "int", nullable: true),
                    CargoSpaceSquareMeters = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "ColorCode", "Name", "PassengerCount", "Type", "VehicleIdentificationNumber" },
                values: new object[] { new Guid("960792ad-4442-42cc-84a9-db47832e77c3"), "", "Golf 6", 0, "Car", "IUKDGHFKLSDFSD3123" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "CargoSpaceSquareMeters", "ColorCode", "Name", "Type", "VehicleIdentificationNumber" },
                values: new object[,]
                {
                    { new Guid("9f5120a6-d33b-4cb7-814e-6e86d3f46269"), 0f, "", "Mercedes Actros", "Truck", "DSKJFGHSDKGDFS231234" },
                    { new Guid("b39f6448-0308-4e59-aee9-5f11e482f2a6"), 0f, "", "Iveco Stralis", "Truck", "HKLSDFBHDS389423" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "ColorCode", "Name", "PassengerCount", "Type", "VehicleIdentificationNumber" },
                values: new object[] { new Guid("ef950b20-03e3-4c33-ac03-9b0e43a363a3"), "", "Chrysler Fifth Avenue", 0, "Car", "SDFKLDSHGSDFG241" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}

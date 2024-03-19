using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AccelerationPropertyChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Acceleration",
                table: "Cars",
                newName: "ZeroToSixtyAcceleration");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CarName", "Engine", "TopSpeed", "Weight", "ZeroToSixtyAcceleration" },
                values: new object[] { "VF-21 ", "Ferrari 065", 210.0, 1645.0, 2.21 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CarName", "Engine", "TopSpeed", "Weight", "ZeroToSixtyAcceleration" },
                values: new object[] { "VF-20", "Ferrari 065", 208.0, 1645.0, 2.3500000000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZeroToSixtyAcceleration",
                table: "Cars",
                newName: "Acceleration");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "Acceleration", "CarName", "Engine", "TopSpeed", "Weight" },
                values: new object[] { 240.0, "leclerc", "6.0 Liter V8", 200.0, 5000.0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "Acceleration", "CarName", "Engine", "TopSpeed", "Weight" },
                values: new object[] { 240.0, "sainz", "6.0 Liter V7", 2180.0, 4000.0 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CarName", "DriverId", "Engine", "HorsePower", "TopSpeed", "Weight" },
                values: new object[] { 3, 300.0, "max", null, "7.0 Liter V8", 0, 2255.0, 2000.0 });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CarName", "DriverId", "Engine", "HorsePower", "TopSpeed", "Weight" },
                values: new object[] { 3, 300.0, "max", null, "7.0 Liter V8", 0, 2255.0, 2000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);
        }
    }
}

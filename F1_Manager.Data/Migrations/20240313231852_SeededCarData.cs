using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededCarData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Drivers_DriverId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CarName", "DriverId", "Engine", "HorsePower", "TopSpeed", "Weight" },
                values: new object[,]
                {
                    { 1, 240.0, "leclerc", null, "6.0 Liter V8", 0, 200.0, 5000.0 },
                    { 2, 240.0, "sainz", null, "6.0 Liter V7", 0, 2180.0, 4000.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Drivers_DriverId",
                table: "Cars",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Drivers_DriverId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Drivers_DriverId",
                table: "Cars",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

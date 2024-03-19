using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZeroToSixtyAcceleration",
                table: "Cars",
                newName: "Acceleration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Acceleration",
                table: "Cars",
                newName: "ZeroToSixtyAcceleration");
        }
    }
}

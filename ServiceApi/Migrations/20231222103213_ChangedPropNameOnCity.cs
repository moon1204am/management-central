using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPropNameOnCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Location_CityId",
                table: "Device");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "City");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_City_CityId",
                table: "Device",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_City_CityId",
                table: "Device");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Location");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Location_CityId",
                table: "Device",
                column: "CityId",
                principalTable: "Location",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

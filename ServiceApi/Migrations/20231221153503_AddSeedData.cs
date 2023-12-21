using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeviceApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Location_LocationId",
                table: "Device");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Location",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Device",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Device_LocationId",
                table: "Device",
                newName: "IX_Device_CityId");

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Suzhou" },
                    { 2, "Hangzhou" },
                    { 3, "Nanjing" },
                    { 4, "Seoul" },
                    { 5, "Busan" },
                    { 6, "Harbin" },
                    { 7, "Changsha" },
                    { 8, "Jeju" },
                    { 9, "Incheon" }
                });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "DeviceId", "CityId", "Date", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Weather Sensor" },
                    { 2, 2, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Weather Sensor" },
                    { 3, 3, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Weather Sensor" },
                    { 4, 4, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Weather Sensor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Location_CityId",
                table: "Device",
                column: "CityId",
                principalTable: "Location",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Location_CityId",
                table: "Device");

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "DeviceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "DeviceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "DeviceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "DeviceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Location",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Device",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Device_CityId",
                table: "Device",
                newName: "IX_Device_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Location_LocationId",
                table: "Device",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

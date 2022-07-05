using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet.Migrations
{
    public partial class CreatingADateForCommute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3812bdb8-341b-4699-8c8c-084423a60432");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c827af54-ce5a-46f3-a70c-073799bfb167");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d107378f-4a15-4b1b-84e5-f2a63cc6d254");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRequested",
                table: "Commutes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "697e0606-5cdc-4f2e-a1be-ae67ca1e7a3a", "4e9fc556-96ea-4dd9-a159-b795ba658253", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc68cfe1-1d9a-467f-a9f5-1c6f58db3b94", "a19b3b01-019f-4f1d-952a-437eda7f5a90", "Commuter", "COMMUTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc50a7a5-9156-4b87-b3d9-3d8b7cc54cfe", "9a014434-e669-4bca-be15-89a3bd2bc1fa", "Driver", "DRIVER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "697e0606-5cdc-4f2e-a1be-ae67ca1e7a3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc68cfe1-1d9a-467f-a9f5-1c6f58db3b94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc50a7a5-9156-4b87-b3d9-3d8b7cc54cfe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRequested",
                table: "Commutes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3812bdb8-341b-4699-8c8c-084423a60432", "6c6cd165-790c-4561-bd0e-204093b019e7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c827af54-ce5a-46f3-a70c-073799bfb167", "d11fb3c9-4654-4d26-b0ba-19fb9d5f7db0", "Driver", "DRIVER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d107378f-4a15-4b1b-84e5-f2a63cc6d254", "9839569f-40d2-4a10-b43a-fa49ccef0fc4", "Commuter", "COMMUTER" });
        }
    }
}

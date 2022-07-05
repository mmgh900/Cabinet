using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet.Migrations
{
    public partial class MakingDriverIdOptionalForCommute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68b8a8ff-cd2c-4b8e-8627-8dac6213e53a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87a16a80-d7d1-454b-a3de-addec5cdcddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4335456-5074-45f1-9a94-a61f157c3780");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Commutes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Commutes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68b8a8ff-cd2c-4b8e-8627-8dac6213e53a", "55731a0e-5836-4dc2-a144-4a041c897577", "Commuter", "COMMUTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87a16a80-d7d1-454b-a3de-addec5cdcddc", "5f34b739-b25c-446e-964a-2e1e7f8782f7", "Driver", "DRIVER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4335456-5074-45f1-9a94-a61f157c3780", "06adcca3-82e5-493b-9e30-ed582f85185d", "Admin", "ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet.Migrations
{
    public partial class SeedingSomeNeighborhoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "124300d5-3e27-40ef-9487-9bc55b6399e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc981b5-c882-4869-94b5-529e7070e5ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f316f70e-af80-4257-85be-f2f9aebfcc67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39924c72-97fc-42cb-a366-ee2843302a50", "891207d8-539d-4856-b787-35416fbc88b5", "Driver", "DRIVER" },
                    { "7718e1b1-f685-45ee-bfdb-3cd9f8cb9491", "3f180033-263d-42b5-a56d-73b0637118be", "Commuter", "COMMUTER" },
                    { "d00b92d0-3301-423e-9d76-e20fa5a3c172", "34acaaa9-5a9f-45b8-bb23-15c7f5394be6", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Neighborhoods",
                columns: new[] { "Id", "CabinetUserId", "Name" },
                values: new object[,]
                {
                    { 1L, null, "Sanabad" },
                    { 2L, null, "Kolahdoz" },
                    { 3L, null, "Moalem" },
                    { 4L, null, "Emam Reza" },
                    { 5L, null, "Azadi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39924c72-97fc-42cb-a366-ee2843302a50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7718e1b1-f685-45ee-bfdb-3cd9f8cb9491");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d00b92d0-3301-423e-9d76-e20fa5a3c172");

            migrationBuilder.DeleteData(
                table: "Neighborhoods",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Neighborhoods",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Neighborhoods",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Neighborhoods",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Neighborhoods",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "124300d5-3e27-40ef-9487-9bc55b6399e1", "f6d9b670-270f-4a9e-998b-0b3284945c99", "Commuter", "COMMUTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bc981b5-c882-4869-94b5-529e7070e5ee", "ac227d9b-c736-4441-8cd9-758cfdfb815e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f316f70e-af80-4257-85be-f2f9aebfcc67", "c78ef8be-add0-44c2-990c-37856f919ffd", "Driver", "DRIVER" });
        }
    }
}

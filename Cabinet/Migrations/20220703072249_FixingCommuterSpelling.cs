using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet.Migrations
{
    public partial class FixingCommuterSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47dc69d4-9f00-4c05-81fe-ef75c0867043");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b1afbc3-cffc-4561-9c34-d96dc1ed0024");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa3983e2-b102-4e2c-b6dc-a1a42930a63b");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "47dc69d4-9f00-4c05-81fe-ef75c0867043", "4e3489f9-28e3-48f1-9872-2149b73be3a1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b1afbc3-cffc-4561-9c34-d96dc1ed0024", "a0fb982d-489e-4005-91a3-82d2e8103729", "Commuter", "COMUTTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa3983e2-b102-4e2c-b6dc-a1a42930a63b", "2cb2629f-a111-4c4c-bef6-d1ee81367a14", "Driver", "DRIVER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet.Migrations
{
    public partial class AddingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

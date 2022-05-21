using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet.Migrations
{
    public partial class Fixingcommmutersandaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Neighborhoods_NeighborhoodId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_NeighborhoodId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId1",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Commuters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Commuters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Commuters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Commuters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Commuters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Commuters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighborhoodId",
                table: "Addresses",
                column: "NeighborhoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Neighborhoods_NeighborhoodId",
                table: "Addresses",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Neighborhoods_NeighborhoodId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_NeighborhoodId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Commuters");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Commuters");

            migrationBuilder.AddColumn<long>(
                name: "NeighborhoodId1",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighborhoodId1",
                table: "Addresses",
                column: "NeighborhoodId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Neighborhoods_NeighborhoodId1",
                table: "Addresses",
                column: "NeighborhoodId1",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

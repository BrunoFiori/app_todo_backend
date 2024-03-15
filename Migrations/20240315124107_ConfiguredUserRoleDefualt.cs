using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Todo_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredUserRoleDefualt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b510a6a-3bad-48f7-9561-d922959d270a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3198671-d7d3-4e38-bacd-9ad7f679c0a6", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bdf86add-3709-4252-8fcd-g8h13029cceb", 0, "b577a9ea-4cfe-44c6-b19b-0a175445e0ee", "admin@gmail.com", true, null, null, false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEA2E3H27Bc2D28SWoLXEfyPCEl+icxLEbdgjB9EuEcsr/iheA2PKLjCXHxFFFgSs6A==", null, false, "", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bdf86add-3709-4252-8fcd-f7e02918bbda", "bdf86add-3709-4252-8fcd-g8h13029cceb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3198671-d7d3-4e38-bacd-9ad7f679c0a6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bdf86add-3709-4252-8fcd-f7e02918bbda", "bdf86add-3709-4252-8fcd-g8h13029cceb" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdf86add-3709-4252-8fcd-g8h13029cceb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b510a6a-3bad-48f7-9561-d922959d270a", null, "User", "USER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App_Todo_Backend.Migrations
{
    /// <inheritdoc />
    public partial class fixLastNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3332bcb8-8e08-4b40-ba19-2420e3f15078");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "956b3d94-162a-4258-b83c-623771c8f17b");

            migrationBuilder.RenameColumn(
                name: "LastNme",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b510a6a-3bad-48f7-9561-d922959d270a", null, "User", "USER" },
                    { "bdf86add-3709-4252-8fcd-f7e02918bbda", null, "Administrator", "ADMINASTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b510a6a-3bad-48f7-9561-d922959d270a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdf86add-3709-4252-8fcd-f7e02918bbda");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "LastNme");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3332bcb8-8e08-4b40-ba19-2420e3f15078", null, "Administrator", "ADMINASTRATOR" },
                    { "956b3d94-162a-4258-b83c-623771c8f17b", null, "User", "USER" }
                });
        }
    }
}

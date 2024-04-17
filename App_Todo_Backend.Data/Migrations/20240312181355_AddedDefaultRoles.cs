using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App_Todo_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3332bcb8-8e08-4b40-ba19-2420e3f15078", null, "Administrator", "ADMINASTRATOR" },
                    { "956b3d94-162a-4258-b83c-623771c8f17b", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedAt", "Description", "Done", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Estudar C# para melhorar minhas habilidades com a linguagem", false, "Estudar C#" },
                    { 2, new DateTime(2024, 2, 27, 18, 27, 45, 0, DateTimeKind.Utc), "Estudar Ciências COntábeis para sustentar o Bruno 💕", false, "Estudar Ciências Contábeis 🤑" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3332bcb8-8e08-4b40-ba19-2420e3f15078");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "956b3d94-162a-4258-b83c-623771c8f17b");

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

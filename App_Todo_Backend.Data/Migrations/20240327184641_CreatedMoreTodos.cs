using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App_Todo_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreatedMoreTodos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3198671-d7d3-4e38-bacd-9ad7f679c0a6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5e53f8d-9b87-4b36-bec6-f7b5e212e1c6", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdf86add-3709-4252-8fcd-g8h13029cceb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "77e4e6ba-2289-4eaf-88ac-a1a10cf97f78", "AQAAAAIAAYagAAAAEDGqcoKAL1m8+mibZls7HtMiD3nV0GDE6Gx8Ricmy7lPxxAQCV+LqdIVIsIIjwjgzQ==" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Example Description 1", "Example 1" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 2", "Exmple 2" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedAt", "Description", "Done", "Title" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 3", false, "Example 3" },
                    { 4, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 4", false, "Exmple 4" },
                    { 5, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 5", false, "Exmple 5" },
                    { 6, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 6", false, "Exmple 6" },
                    { 7, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 7", false, "Exmple 7" },
                    { 8, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 8", false, "Exmple 8" },
                    { 9, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 9", false, "Exmple 9" },
                    { 10, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 10", false, "Exmple 10" },
                    { 11, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 11", false, "Exmple 11" },
                    { 12, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 12", false, "Exmple 12" },
                    { 13, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 13", false, "Exmple 13" },
                    { 14, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 14", false, "Exmple 14" },
                    { 15, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Example Description 15", false, "Exmple 15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5e53f8d-9b87-4b36-bec6-f7b5e212e1c6");

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3198671-d7d3-4e38-bacd-9ad7f679c0a6", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdf86add-3709-4252-8fcd-g8h13029cceb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b577a9ea-4cfe-44c6-b19b-0a175445e0ee", "AQAAAAIAAYagAAAAEA2E3H27Bc2D28SWoLXEfyPCEl+icxLEbdgjB9EuEcsr/iheA2PKLjCXHxFFFgSs6A==" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Estudar C# para melhorar minhas habilidades com a linguagem", "Estudar C#" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 27, 18, 27, 45, 0, DateTimeKind.Utc), "Estudar Ciências COntábeis para sustentar o Bruno 💕", "Estudar Ciências Contábeis 🤑" });
        }
    }
}

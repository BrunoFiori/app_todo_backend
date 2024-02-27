using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App_Todo_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialseed_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Email", "HashPassword", "Name" },
                values: new object[,]
                {
                    { 1, null, "brunocfiori@hotmail.com", "AHyrwxO7KuCAR9tGtDmkqULcKbcXqxbzfpWzEj+wyl893W7cUMejonoF+KaCT9GbWQ==", "Bruno Canteiro Fiori" },
                    { 2, null, "lesemensato@gmail.com", "AL0UYOixIiOztyrNtu5/E8kPO5BXJkJpJYFKd549famQB2mGF+ADGEvJhYMlne8ppg==", "Leticia Semensato" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Description", "Done", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 27, 15, 16, 25, 0, DateTimeKind.Utc), "Estudar C# para melhorar minhas habilidades com a linguagem", false, "Estudar C#" },
                    { 2, 2, new DateTime(2024, 2, 27, 18, 27, 45, 0, DateTimeKind.Utc), "Estudar Ciências COntábeis para sustentar o Bruno 💕", false, "Estudar Ciências Contábeis 🤑" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

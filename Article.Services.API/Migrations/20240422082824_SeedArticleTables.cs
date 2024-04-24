using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Services.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedArticleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "content content content 111", new DateTime(2024, 4, 22, 11, 28, 24, 75, DateTimeKind.Local).AddTicks(9875), "article1" },
                    { 2, "content content content 222", new DateTime(2024, 4, 22, 11, 28, 24, 75, DateTimeKind.Local).AddTicks(9947), "article2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

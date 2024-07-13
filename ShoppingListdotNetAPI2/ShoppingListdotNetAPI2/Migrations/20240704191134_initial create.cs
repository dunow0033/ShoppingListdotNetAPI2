using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingListdotNetAPI2.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPickedUp = table.Column<bool>(type: "bit", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShoppingListItems",
                columns: new[] { "Id", "CreatedAt", "IsPickedUp", "Item" },
                values: new object[,]
                {
                    { new Guid("7ed75077-a8f9-4707-9d69-3d1f7c99ee7e"), new DateTime(2024, 7, 4, 15, 11, 33, 43, DateTimeKind.Local).AddTicks(2542), false, "Flour" },
                    { new Guid("9f7fb0cf-4601-415b-9a12-1c00cb4054ea"), new DateTime(2024, 7, 4, 15, 11, 33, 43, DateTimeKind.Local).AddTicks(2537), false, "Eggs" },
                    { new Guid("afe8c295-69a5-4bcb-999d-f77cb2825b3d"), new DateTime(2024, 7, 4, 15, 11, 33, 43, DateTimeKind.Local).AddTicks(2520), false, "Milk" },
                    { new Guid("e0f51482-b9e6-475e-b079-091bde7e99bf"), new DateTime(2024, 7, 4, 15, 11, 33, 43, DateTimeKind.Local).AddTicks(2532), false, "Sandwiches" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListItems");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework2505.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Dispositivos electrónicos y gadgets.", "Electrónica" },
                    { 2, "Prendas de vestir para todas las edades.", "Ropa" },
                    { 3, "Artículos para el hogar y decoración.", "Hogar" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Descripcion", "FechaCreacion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Teléfono inteligente de última generación.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone", 699.99m, 50 },
                    { 2, 1, "Portátil potente para trabajo y entretenimiento.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 1299.99m, 30 },
                    { 3, 2, "Camiseta de algodón para uso diario.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Camiseta", 19.99m, 100 },
                    { 4, 3, "Sofá cómodo para sala de estar.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofá", 499.99m, 20 },
                    { 5, 3, "Lámpara de mesa moderna para iluminación ambiental.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lámpara de mesa", 89.99m, 40 },
                    { 6, 1, "Auriculares inalámbricos con cancelación de ruido.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auriculares", 199.99m, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibrosAutores",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "INTEGER", nullable: false),
                    LibrosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosAutores", x => new { x.AutoresId, x.LibrosId });
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nombre", "Pais" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", "Reino Unido" },
                    { 2, "Brandon Sanderson", "Estados Unidos" },
                    { 3, "Neil Gaiman", "Reino Unido" },
                    { 4, "Terry Pratchett", "Reino Unido" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "Anio", "ISBN", "Titulo" },
                values: new object[,]
                {
                    { 1, 1954, "978-0261103252", "El Señor de los Anillos" },
                    { 2, 2006, "978-8466656948", "El Imperio Final" },
                    { 3, 1990, "978-8445077926", "Buenos Presagios" },
                    { 4, 1937, "978-0261102217", "El Hobbit" }
                });

            migrationBuilder.InsertData(
                table: "LibrosAutores",
                columns: new[] { "AutoresId", "LibrosId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosAutores_LibrosId",
                table: "LibrosAutores",
                column: "LibrosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosAutores");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}

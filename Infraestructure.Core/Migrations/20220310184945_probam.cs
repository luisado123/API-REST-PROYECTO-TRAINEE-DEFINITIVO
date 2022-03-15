using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class probam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autores",
                schema: "Library",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Library",
                table: "Autores");

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                schema: "Library",
                table: "Autores",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autores",
                schema: "Library",
                table: "Autores",
                column: "IdAutor");

            migrationBuilder.CreateTable(
                name: "Autores_has_libros",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutor = table.Column<int>(nullable: false),
                    IdBook = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores_has_libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autores_has_libros_Autores_IdAutor",
                        column: x => x.IdAutor,
                        principalSchema: "Library",
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autores_has_libros_Book_IdBook",
                        column: x => x.IdBook,
                        principalSchema: "Library",
                        principalTable: "Book",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_has_libros_IdAutor",
                schema: "Library",
                table: "Autores_has_libros",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_has_libros_IdBook",
                schema: "Library",
                table: "Autores_has_libros",
                column: "IdBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores_has_libros",
                schema: "Library");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autores",
                schema: "Library",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                schema: "Library",
                table: "Autores");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Library",
                table: "Autores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autores",
                schema: "Library",
                table: "Autores",
                column: "Id");
        }
    }
}

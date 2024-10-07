using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyBooksApi.Migrations
{
    /// <inheritdoc />
    public partial class fkLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Generos_GeneroId",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Livros",
                newName: "GeneroLivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_GeneroId",
                table: "Livros",
                newName: "IX_Livros_GeneroLivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Generos_GeneroLivroId",
                table: "Livros",
                column: "GeneroLivroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Generos_GeneroLivroId",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "GeneroLivroId",
                table: "Livros",
                newName: "GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_GeneroLivroId",
                table: "Livros",
                newName: "IX_Livros_GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Generos_GeneroId",
                table: "Livros",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

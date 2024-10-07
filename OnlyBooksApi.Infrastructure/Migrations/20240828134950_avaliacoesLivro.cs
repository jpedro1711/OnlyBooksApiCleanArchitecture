using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyBooksApi.Migrations
{
    /// <inheritdoc />
    public partial class avaliacoesLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalAvaliações",
                table: "Livros",
                newName: "TotalAvaliações");

            migrationBuilder.AddColumn<int>(
                name: "SomaTotalAvaliaçoes",
                table: "Livros",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomaTotalAvaliaçoes",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "TotalAvaliações",
                table: "Livros",
                newName: "totalAvaliações");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyBooksApi.Migrations
{
    /// <inheritdoc />
    public partial class addAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "totalAvaliações",
                table: "Livros",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalAvaliações",
                table: "Livros");
        }
    }
}

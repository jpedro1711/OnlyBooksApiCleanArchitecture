using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyBooksApi.Migrations
{
    /// <inheritdoc />
    public partial class manyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Reservas_ReservaId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_ReservaId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Livros");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "LivroReserva",
                columns: table => new
                {
                    LivrosId = table.Column<int>(type: "int", nullable: false),
                    ReservasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroReserva", x => new { x.LivrosId, x.ReservasId });
                    table.ForeignKey(
                        name: "FK_LivroReserva_Livros_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroReserva_Reservas_ReservasId",
                        column: x => x.ReservasId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LivroReserva_ReservasId",
                table: "LivroReserva",
                column: "ReservasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroReserva");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_ReservaId",
                table: "Livros",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Reservas_ReservaId",
                table: "Livros",
                column: "ReservaId",
                principalTable: "Reservas",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class MembroTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembroTipoId",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembroTipo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "INTEGER", nullable: false),
                    SignUpFee = table.Column<short>(type: "INTEGER", nullable: false),
                    DuracaoMeses = table.Column<byte>(type: "INTEGER", nullable: false),
                    Desconto = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroTipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_MembroTipoId",
                table: "Clientes",
                column: "MembroTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_MembroTipo_MembroTipoId",
                table: "Clientes",
                column: "MembroTipoId",
                principalTable: "MembroTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_MembroTipo_MembroTipoId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "MembroTipo");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_MembroTipoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MembroTipoId",
                table: "Clientes");
        }
    }
}

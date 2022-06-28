using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    public partial class UpTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_MembroTipo_MembroTipoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Genero_GeneroId",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembroTipo",
                table: "MembroTipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.RenameTable(
                name: "MembroTipo",
                newName: "MembroTipos");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembroTipos",
                table: "MembroTipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_MembroTipos_MembroTipoId",
                table: "Clientes",
                column: "MembroTipoId",
                principalTable: "MembroTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_MembroTipos_MembroTipoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembroTipos",
                table: "MembroTipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "MembroTipos",
                newName: "MembroTipo");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembroTipo",
                table: "MembroTipo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_MembroTipo_MembroTipoId",
                table: "Clientes",
                column: "MembroTipoId",
                principalTable: "MembroTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Genero_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    public partial class InsertGeneros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Popolar tabela de Hgerneros dos Filmes 
            migrationBuilder.Sql("INSERT INTO MembroTipos (id, Nome, SignUpFee, DuracaoMeses, Desconto ) VALUES (1, 'Free', 0, 0, 0) ");
            migrationBuilder.Sql("INSERT INTO MembroTipos (id, Nome, SignUpFee, DuracaoMeses, Desconto ) VALUES (2, 'Mensal', 20, 1, 10 ");
            migrationBuilder.Sql("INSERT INTO MembroTipos (id, Nome, SignUpFee, DuracaoMeses, Desconto ) VALUES (3, 'Semestral', 50, 6, 20) ");
            migrationBuilder.Sql("INSERT INTO MembroTipos (id, Nome, SignUpFee, DuracaoMeses, Desconto ) VALUES (4, 'Anual', 90, 12, 30) ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

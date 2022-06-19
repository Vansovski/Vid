using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class PopulateMembroTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembroTipo (Id, SignUpFee, DuracaoMeses, Desconto) VALUES (1,0,0,0)");
            migrationBuilder.Sql("INSERT INTO MembroTipo (Id, SignUpFee, DuracaoMeses, Desconto) VALUES (2,30,1,10)");
            migrationBuilder.Sql("INSERT INTO MembroTipo (Id, SignUpFee, DuracaoMeses, Desconto) VALUES (3,90,3,15)");
            migrationBuilder.Sql("INSERT INTO MembroTipo (Id, SignUpFee, DuracaoMeses, Desconto) VALUES (4,300,12,20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

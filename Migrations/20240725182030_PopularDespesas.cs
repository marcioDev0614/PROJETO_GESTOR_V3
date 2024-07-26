using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_GESTOR_V3.Migrations
{
    public partial class PopularDespesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Despesas(DespesasId,Titulo,Valor,DataVencimento,Situacao) VALUES (1,'Compra inicio do mês',680.50,GETDATE(),0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Despesas");
        }
    }
}

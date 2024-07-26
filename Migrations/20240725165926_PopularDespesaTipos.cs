using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_GESTOR_V3.Migrations
{
    public partial class PopularDespesaTipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DespesaTipos (DespesaNome,Descricao)" +
                "VALUES('Feira', 'Despesa relacionada e compras do mês')");
            migrationBuilder.Sql("INSERT INTO DespesaTipos (DespesaNome,Descricao)" +
                "VALUES('Educação', 'Despesa relacionada a escola de Matheus / Julia')");
            migrationBuilder.Sql("INSERT INTO DespesaTipos (DespesaNome,Descricao) " +
                "VALUES('Saúde', 'Despesa relacionada a medicamentos e plano de saúde')");
            migrationBuilder.Sql("INSERT INTO DespesaTipos (DespesaNome,Descricao) " +
                "VALUES('Projeto', 'Despesa relacionada a custos com obras e aquisições de bens: Moveis e Imoveis')");
            migrationBuilder.Sql("INSERT INTO DespesaTipos (DespesaNome,Descricao) " +
                "VALUES('Lazer', 'Despesa relacionada ao entreitenimento')");
            migrationBuilder.Sql("INSERT INTO DespesaTipos (DespesaNome,Descricao) " +
                "VALUES('Diversas', 'Despesas que surgem no mês corrente')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM DespesaTipos");
        }
    }
}

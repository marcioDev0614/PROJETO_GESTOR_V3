using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_GESTOR_V3.Migrations
{
    public partial class PrimeiroInsertTabelaJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Jogos (FabricanteId,Titulo,Desenvolvedora,DataDeCadastro,Plataforma)" +
              "VALUES(2,'Max Payne 3', 'RockStar', GETDATE(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Jogos");
        }
    }
}

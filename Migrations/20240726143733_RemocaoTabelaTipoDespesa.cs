using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_GESTOR_V3.Migrations
{
    public partial class RemocaoTabelaTipoDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_DespesaTipos_DespesasId",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "DespesaTipos");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_DespesasId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "DespesasId",
                table: "Despesas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DespesasId",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DespesaTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DespesaNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaTipos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_DespesasId",
                table: "Despesas",
                column: "DespesasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_DespesaTipos_DespesasId",
                table: "Despesas",
                column: "DespesasId",
                principalTable: "DespesaTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

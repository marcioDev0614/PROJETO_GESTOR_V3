using Microsoft.AspNetCore.Mvc.RazorPages;
using PROJECT_GESTOR_V3.Enums;
using System;

namespace PROJECT_GESTOR_V3.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Desenvolvedora { get; set; }

        public DateTime DataDeCadastro { get; set; }
        public PlataformaTipo Plataforma { get; set; }

        public int FabricaId { get; set; }
        public FabricaModel Fabrica { get; set; }

        public GameModel() { }

        public GameModel(int id, string titulo, string desenvolvedora, DateTime dataDeCadastro, PlataformaTipo plataforma, int fabricaId, FabricaModel fabrica)
        {
            Id = id;
            Titulo = titulo;
            Desenvolvedora = desenvolvedora;
            DataDeCadastro = dataDeCadastro;
            Plataforma = plataforma;
            FabricaId = fabricaId;
            Fabrica = fabrica;
        }
    }
}

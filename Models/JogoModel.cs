using PROJECT_GESTOR_V3.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PROJECT_GESTOR_V3.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Desenvolvedora { get; set; }
        [Display(Name = "Data de Cadastro")]

        public DateTime? DataDeCadastro { get; set; }

        public PlataformaTipo Plataforma { get; set; }

        public FabricanteModel Fabricante { get; set; }

        public JogoModel()
        {

        }

        public JogoModel(int id, string titulo, string desenvolvedora, DateTime? dataDeCadastro, PlataformaTipo plataforma, FabricanteModel fabricante)
        {
            Id = id;
            Titulo = titulo;
            Desenvolvedora = desenvolvedora;
            DataDeCadastro = dataDeCadastro;
            Plataforma = plataforma;
            Fabricante = fabricante;
        }
    }
}

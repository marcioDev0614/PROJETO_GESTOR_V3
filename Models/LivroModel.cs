using System.ComponentModel.DataAnnotations;
using PROJECT_GESTOR_V3.Enums;
using System;

namespace PROJECT_GESTOR_V3.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public GeneroTipo Genero { get; set; }
        public DateTime Data_de_Cadastro { get; set; }
    }
}

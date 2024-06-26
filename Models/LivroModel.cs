using System.ComponentModel.DataAnnotations;
using PROJECT_GESTOR_V3.Enums;
using System;

namespace PROJECT_GESTOR_V3.Models
{
    public class LivroModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o titulo.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Favor informar o autor.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Favor informar o genero.")]
        public GeneroTipo Genero { get; set; }

        [Required(ErrorMessage = "Favor informar a data de criação.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_de_Cadastro { get; set; }
    }
}

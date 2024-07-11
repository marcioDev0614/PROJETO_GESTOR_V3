using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PROJECT_GESTOR_V3.Enums;

namespace PROJECT_GESTOR_V3.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar o login do usuário.")]

        public string Login { get; set; }

        [Required(ErrorMessage = "Favor informar o e-mail do usuário.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilTipo? Perfil { get; set; }

    }
}

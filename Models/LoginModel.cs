using System;
using System.ComponentModel.DataAnnotations;

namespace PROJECT_GESTOR_V3.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PROJECT_GESTOR_V3.Enums;
using PROJECT_GESTOR_V3.Helper;

namespace PROJECT_GESTOR_V3.Models
{
    public class UsuarioModel
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

        [Required(ErrorMessage = "Favor informar a senha do usuário.")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}

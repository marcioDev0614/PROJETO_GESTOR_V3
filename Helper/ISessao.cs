using PROJECT_GESTOR_V3.Models;
using System;

namespace PROJECT_GESTOR_V3.Helper
{
    public interface ISessao
    {
        public void CriarSessaoDoUsuario(UsuarioModel usuarioModel);
        public void RemoverSessaoDoUsuario();

        UsuarioModel BuscarSessaoDoUsuario();
    }
}

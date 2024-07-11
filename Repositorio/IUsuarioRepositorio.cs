using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        
        UsuarioModel Adicionar(UsuarioModel usuarioModel);

        UsuarioModel ListarPorId(int id);

        List<UsuarioModel> BuscarTodos();

        UsuarioModel Atualizar(UsuarioModel usuarioModel);

        bool Apagar(int id);


    }
}

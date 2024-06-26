using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public interface ILivroRepositorio
    {
        LivroModel Adicionar(LivroModel livroModel);

        LivroModel ListarPorId(int id);

        List<LivroModel> BuscarTodos();

        LivroModel Atualizar(LivroModel livroModel);

        bool Apagar(int id);


    }
}

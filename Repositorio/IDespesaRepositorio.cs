using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public interface IDespesaRepositorio
    {
        List<DespesaModel> BuscarTodos();

        DespesaModel BuscarPorId(int id);

        DespesaModel Adicionar(DespesaModel despesaModel);

        DespesaModel Atualizar(DespesaModel despesaModel);

        bool Apagar(int id);

    }
}

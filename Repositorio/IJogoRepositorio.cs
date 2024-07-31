using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public interface IJogoRepositorio
    {
        IEnumerable<JogoModel> Jogos { get; }

        JogoModel GetJogoByID(int id);


    }
}

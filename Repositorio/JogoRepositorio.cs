using Microsoft.EntityFrameworkCore;
using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public class JogoRepositorio : IJogoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public JogoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IEnumerable<JogoModel> Jogos => _bancoContext.Jogos.Include(f => f.Fabricante);
        public JogoModel GetJogoByID(int id)
        {
            return _bancoContext.Jogos.FirstOrDefault(x => x.Id == id);
        }
    }
}

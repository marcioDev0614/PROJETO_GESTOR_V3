using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROJECT_GESTOR_V3.Services
{
    public class GameService
    {
        private readonly BancoContext _bancoContext;

        public GameService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<GameModel> FindAll()
        {
            return _bancoContext.Games.ToList();
        }

        public void Inserir(GameModel gameModel)
        {
            gameModel.Fabrica = _bancoContext.Fabricas.First();
                      
            _bancoContext.SaveChanges();

        }
    }
}

using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROJECT_GESTOR_V3.Services
{
    public class FabricaService
    {
        private readonly BancoContext _bancoContext;

        public FabricaService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<FabricaModel> FindAll()
        {
            return _bancoContext.Fabricas.OrderBy(x => x.Nome).ToList();
        }
    }
}

using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public class FabricanteRepositorio : IFabricanteRepositorio
    {
        private readonly BancoContext  _bancoContext;

        public FabricanteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;   
        }

        public IEnumerable<FabricanteModel> Fabricantes => _bancoContext.Fabricantes;
    }
}

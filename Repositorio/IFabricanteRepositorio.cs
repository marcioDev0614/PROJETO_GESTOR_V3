using System.Collections.Generic;
using PROJECT_GESTOR_V3.Models;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public interface IFabricanteRepositorio
    {
        IEnumerable<FabricanteModel> Fabricantes { get; }
    }
}

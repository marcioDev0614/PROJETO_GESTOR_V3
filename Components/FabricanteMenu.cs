using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Repositorio;
using System.Linq;

namespace PROJECT_GESTOR_V3.Components
{
    public class FabricanteMenu : ViewComponent
    {
        private readonly IFabricanteRepositorio _fabricanteRepositorio;

        public FabricanteMenu(IFabricanteRepositorio fabricanteRepositorio)
        {
            _fabricanteRepositorio = fabricanteRepositorio;
        }

        public IViewComponentResult InvoKe()
        {
            var fabricantes = _fabricanteRepositorio.Fabricantes.OrderBy(c => c.Descricao);
            return View(fabricantes);
        }
    }
}

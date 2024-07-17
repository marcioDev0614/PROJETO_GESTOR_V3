using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Filters;

namespace PROJECT_GESTOR_V3.Controllers
{

    public class RestritoController : Controller
    {
        [PaginaParaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}

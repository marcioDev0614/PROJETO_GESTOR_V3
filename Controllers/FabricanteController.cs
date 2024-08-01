using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class FabricanteController : Controller
    {
        public IActionResult Index()
        {

            List<Fabricante> list = new List<Fabricante>();
            list.Add(new Fabricante { Id = 1, Nome = "Microsoft" }) ;
            list.Add(new Fabricante { Id = 2, Nome = "Sony" });

            return View(list);
        }
    }
}

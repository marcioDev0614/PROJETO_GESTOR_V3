using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Repositorio;
using System;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoController(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }

        public IActionResult Index()
        {
            ViewData["Titulo"] = "Lista de Jogos";
            ViewData["Data"] = DateTime.Now;

            var list = _jogoRepositorio.Jogos;
            return View(list);
        }
    }
}

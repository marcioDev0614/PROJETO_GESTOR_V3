using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Services;
using PROJECT_GESTOR_V3.ViewModel;
using System;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class GameController : Controller
    {
        private readonly GameService _gameService;
        private readonly FabricaService _fabricaService;

        public GameController(GameService gameService, FabricaService fabricaService)
        {
            _gameService = gameService;
            _fabricaService = fabricaService;
        }

        public IActionResult Index()
        {
            var list = _gameService.FindAll();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameModel gameModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _gameService.Inserir(gameModel);
                    TempData["MensagemSucesso"] = "Game cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(gameModel);

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! não foi possível cadastrar o seu game. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Create()
        {
            var fabricas = _fabricaService.FindAll();

            var viewModel = new GameFormViewModel { Fabricas= fabricas };

            return View(viewModel);
        }
    }
}

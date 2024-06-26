using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Repositorio;
using PROJECT_GESTOR_V3.Models;
using System;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public IActionResult Index()
        {
            var list = _livroRepositorio.BuscarTodos();

            return View(list);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(LivroModel livroModel)
        {
            if(ModelState.IsValid)
            {
                _livroRepositorio.Adicionar(livroModel);
                return RedirectToAction("Index");
            }
            
            return View(livroModel);
      
        }

        public IActionResult Editar(int id)
        {
            LivroModel livroModel = _livroRepositorio.ListarPorId(id);
            return View(livroModel);
        }

        [HttpPost]
        public IActionResult Alterar(LivroModel livroModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Atualizar(livroModel);
                    return RedirectToAction("Index");
                }

                return View("Editar", livroModel);
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index");
            }
      
    }
        public IActionResult ApagarConfirmacao(int id)
        {
            LivroModel livroModel = _livroRepositorio.ListarPorId(id);
            return View(livroModel);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _livroRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Livro removido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops! não foi possível apagar o seu livro.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! não foi possível apagar o seu livro. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}

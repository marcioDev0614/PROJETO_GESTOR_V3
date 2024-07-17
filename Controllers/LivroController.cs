using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Repositorio;
using PROJECT_GESTOR_V3.Models;
using System;
using PROJECT_GESTOR_V3.Filters;

namespace PROJECT_GESTOR_V3.Controllers
{
    [PaginaParaUsuarioLogado]
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

            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Adicionar(livroModel);
                    TempData["MensagemSucessoLivro"] = "Livro cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(livroModel);

            }
            catch (Exception erro)
            {

                TempData["MensagemErrolivro"] = $"Ops! não foi possível cadastrar o seu livro. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
      
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
                    TempData["MensagemSucessoLivro"] = "Livro atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", livroModel);
            }
            catch (Exception erro)
            {

                TempData["MensagemErrolivro"] = $"Ops! não foi possível atualizar o seu livro. Detalhe do erro: {erro.Message}";
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
                    TempData["MensagemSucessoLivro"] = "Livro removido com sucesso!";
                }
                else
                {
                    TempData["MensagemErroLivro"] = "Ops! não foi possível apagar o seu livro.";
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

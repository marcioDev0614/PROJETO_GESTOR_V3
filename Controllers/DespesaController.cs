using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Repositorio;
using System;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class DespesaController : Controller
    {
        private readonly IDespesaRepositorio _despesaRepositorio;

        public DespesaController(IDespesaRepositorio despesaRepositorio)
        {
            _despesaRepositorio = despesaRepositorio;
        }

        public IActionResult Index()
        {
            var totalDespesasApagar = _despesaRepositorio.CalcularTotalDespesasApagar();
            var totalDespesasPago = _despesaRepositorio.CalcularTotalDespesasPago();
            ViewBag.TotalDespesas = totalDespesasApagar;
            ViewBag.TotalDespesasPago = totalDespesasPago;
            var list = _despesaRepositorio.BuscarTodos();

            return View(list);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            DespesaModel despesaModel = _despesaRepositorio.BuscarPorId(id);
            return View(despesaModel);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            DespesaModel despesaModel = _despesaRepositorio.BuscarPorId(id);
            return View(despesaModel);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _despesaRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Despesa removida com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops! não foi possível apagar a sua despesa.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! não foi possível apagar a sua despesa. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(DespesaModel despesaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _despesaRepositorio.Atualizar(despesaModel);
                    TempData["MensagemSucesso"] = "Despesa atualizada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", despesaModel);
            }
            catch (Exception erro)
            {

                TempData["MensagemErrolivro"] = $"Ops! não foi possível atualizar a sua despesa. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(DespesaModel despesaModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _despesaRepositorio.Adicionar(despesaModel);
                    TempData["MensagemSucesso"] = "Despesa cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(despesaModel);

            }
            catch (Exception erro)
            {

                TempData["MensagemErrolivro"] = $"Ops! não foi possível cadastrar a sua despesa. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}

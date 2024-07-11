using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Repositorio;
using System;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuarioModel = _usuarioRepositorio.ListarPorId(id);
            return View(usuarioModel);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil

                    };

                   usuario =  _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucessoUsuario"] = "Usuário atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (Exception erro)
            {

                TempData["MensagemErroUsuario"] = $"Ops! não foi possível atualizar o seu usuário. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuarioModel = _usuarioRepositorio.ListarPorId(id);
            return View(usuarioModel);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucessoUsuario"] = "Usuário removido com sucesso!";
                }
                else
                {
                    TempData["MensagemErroUsuário"] = "Ops! não foi possível apagar o seu usuário.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! não foi possível apagar o seu usuário. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuarioModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuarioModel);
                    TempData["MensagemSucessoUsuario"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuarioModel);

            }
            catch (Exception erro)
            {

                TempData["MensagemErroUsuario"] = $"Ops! não foi possível cadastrar o seu usuário. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}

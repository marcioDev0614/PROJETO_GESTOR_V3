using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Models;
using System;
using PROJECT_GESTOR_V3.Repositorio;
using PROJECT_GESTOR_V3.Helper;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao) 
        {
            _usuarioRepositorio= usuarioRepositorio;
            _sessao= sessao;
        }
        public IActionResult Index()
        {
            // Se o usuário estiver logado, redirecionar para a home
            //if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }


        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErroLogin"] = $"Senha do usuário inválida. Por favor, tente novamente.";
                    }

                    TempData["MensagemErroLogin"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                    
                }

                return View("Index");
            }
            catch (Exception)
            {

                TempData["MensagemErroLogin"] = $"Ops! não foi possível realizar o login, tente novamente.";
                return RedirectToAction("Index");
            }
        }
    }
}

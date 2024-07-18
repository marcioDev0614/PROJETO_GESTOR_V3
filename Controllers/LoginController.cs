﻿using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Models;
using System;
using PROJECT_GESTOR_V3.Repositorio;
using PROJECT_GESTOR_V3.Helper;
using PROJECT_GESTOR_V3.Filters;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email) 
        {
            _usuarioRepositorio= usuarioRepositorio;
            _sessao= sessao;
            _email= email;
        }
        public IActionResult Index()
        {
            // Se o usuário estiver logado, redirecionar para a home
            //if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
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

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Login, redefinirSenhaModel.Email);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema Gestor v3 - Nova Senha.", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente";
                        }
                       
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não foi possível redefinir sua senha. Por favor, verifique os dados informados.";

                }

                return View("Index");
            }
            catch (Exception)
            {

                TempData["MensagemErro"] = $"Ops! não foi possível redefinir sua senha, tente novamente.";
                return RedirectToAction("Index");
            }
        }
    }
}

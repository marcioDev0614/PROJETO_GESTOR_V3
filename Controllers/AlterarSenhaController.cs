using Microsoft.AspNetCore.Mvc;
using PROJECT_GESTOR_V3.Helper;
using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Repositorio;

namespace PROJECT_GESTOR_V3.Controllers
{
    public class AlterarSenhaController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();

                    alterarSenhaModel.Id = usuarioLogado.Id;
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"{erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}

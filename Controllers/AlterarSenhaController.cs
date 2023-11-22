using CadastroDeContatos.Helper;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuariorepositorio;
        private readonly ISessao _sessao;
        public AlterarSenhaController (IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuariorepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarsenhamodel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarsenhamodel.Id = usuarioLogado.Id;
                if(ModelState.IsValid)
                {
                    _usuariorepositorio.AlterarSenha(alterarsenhamodel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarsenhamodel);
                }

                return View("Index", alterarsenhamodel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha. Tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarsenhamodel);
            }
        }
    }
}

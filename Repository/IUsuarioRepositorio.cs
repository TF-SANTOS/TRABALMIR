using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repository
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListaPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarsenhamodel);
        bool Apagar(int id);
    }
}

using CadastroDeContatos.Enums;
using CadastroDeContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuário!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do Usuário!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do Usuário!")]
        [EmailAddress(ErrorMessage = "Digite um E-mail Válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o Perfil do Usuário!")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a Senha do Usuário!")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}

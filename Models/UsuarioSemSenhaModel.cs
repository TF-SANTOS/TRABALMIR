using CadastroDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class UsuarioSemSenhaModel
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
    }
}

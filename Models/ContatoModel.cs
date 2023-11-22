using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Contato!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do Contato!")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do Contato!")]
        [Phone(ErrorMessage = "O Celular informado não é válido!")]
        public string Celular { get; set; }

    }
}

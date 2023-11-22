using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        public string Email { get; set; }
    }
}

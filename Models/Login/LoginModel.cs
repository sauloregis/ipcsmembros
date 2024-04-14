using ipcsmembros.Enum;
using System.ComponentModel.DataAnnotations;

namespace ipcsmembros.Models.Login
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }


    }
}

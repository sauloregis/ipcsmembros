using System.ComponentModel.DataAnnotations;

namespace ipcsmembros.ViewModels.Membros
{
    public class ListarMembroViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; } = string.Empty; //atribuir valor padrão nulo pra não salvar sem nada 
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }
        [Display(Name = "Tipo de Membro")]
        public string TipoMembro { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}

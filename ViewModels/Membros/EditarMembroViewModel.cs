using ipcsmembros.Enum;
using System.ComponentModel.DataAnnotations;

namespace ipcsmembros.ViewModels.Membros
{
    public class EditarMembroViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; } = string.Empty; //atribuir valor padrão nulo pra não salvar sem nada 
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }
        [Display(Name = "Tipo de Membro")]
        public EnumTipoMembro TipoMembro { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}

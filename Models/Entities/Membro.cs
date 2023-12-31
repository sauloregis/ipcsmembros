using ipcsmembros.Enum;

namespace ipcsmembros.Models.Entities
{
    public class Membro
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; } = string.Empty; //atribuir valor padrão nulo pra não salvar sem nada 
        public string Email { get; set;}
        public string? Celular { get; set; } = string.Empty;
        public string Sexo { get; set;}
        public EnumTipoMembro TipoMembro { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
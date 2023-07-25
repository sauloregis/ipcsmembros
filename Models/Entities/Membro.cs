namespace ipcsmembros.Models.Entities
{
    public class Membro
    {
        public int Id { get; set; }
        public string  Nome { get; set; } = string.Empty; //atribuir valor padrão nulo pra não salvar sem nada 
        public string Email { get; set;} = string.Empty; 
        public DateTime DataNascimento { get; set; }
    }
}
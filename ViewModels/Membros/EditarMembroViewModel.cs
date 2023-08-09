namespace ipcsmembros.ViewModels.Membros
{
    public class EditarMembroViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; //atribuir valor padrão nulo pra não salvar sem nada 
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}

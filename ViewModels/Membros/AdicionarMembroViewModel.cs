namespace ipcsmembros.ViewModels.Membros
{
    public class AdicionarMembroViewModel
    {
        public bool Ativo { get; set; }
        public string Nome { get; set; } = string.Empty; //atribuir valor padrão nulo pra não salvar sem nada 
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }
        public string TipoMembro { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}

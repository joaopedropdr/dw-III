namespace ControleFinanceiro.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Celular { get; set; }
        public bool? Ativo { get; set; }

        public ICollection<ContaBancaria> UsuarioContas = new List<ContaBancaria>(); // Relacionamento com as contas bancárias do usuário

    }
}

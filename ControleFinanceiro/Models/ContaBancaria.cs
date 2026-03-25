namespace ControleFinanceiro.Models
{
    public class ContaBancaria
    {

        public int Id { get; set; }
        public string? InstituicaoBancaria { get; set; }
        public double valorEntrada  { get; set; } 
        public double valorAnterior  { get; set; } 
        public double valorPosterior  { get; set; } 
        public decimal Saldo { get; set; }
        public string? Observacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        // Relacionamento com o usuário
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } // Navegação para o usuário dono da conta
    }
}

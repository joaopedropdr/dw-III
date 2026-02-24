using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        // Tratando o Ra. Todo tratamento precisa estar acima da variavel que vai ser tratada
        // Display muda o nome para RA quando aparecer para o usuario
        [Display(Name = "RA")]
        // Menssagem de erro caso ele não seja preenchido
        [Required(ErrorMessage = "O RA é Obrigatório")]
        // Trata o tamanho dele
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O RA deve ter entre 4 e 10 caracteres")]
        public string? Ra { get; set; }
        // Relacionamento com a classe Usuario 
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}

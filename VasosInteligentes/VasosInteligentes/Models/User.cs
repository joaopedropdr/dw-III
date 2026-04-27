using System.ComponentModel.DataAnnotations;

namespace VasosInteligentes.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Celular { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="E-mail Inválido")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}

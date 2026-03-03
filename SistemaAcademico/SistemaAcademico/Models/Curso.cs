namespace SistemaAcademico.Models
{
    public class Curso
    {
        public int CursoId { get; set; }

        public string? Nome { get; set; }
        public int Vagas { get; set; }
        // Coleção criada para pegar as disciplinas do curso
        public ICollection<Disciplina>? Disciplinas { get; set; }
    }
}

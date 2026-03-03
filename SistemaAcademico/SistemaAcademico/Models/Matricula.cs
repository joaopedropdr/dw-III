using Microsoft.VisualBasic;

namespace SistemaAcademico.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public DateTime DataMatricula { get; set; }
        // Relacionamento com aluno e curso
        public int AlunoId { get; set; }
        public int CursoId { get;set; }
        public Curso? Curso { get; set; }
        public Aluno? Aluno { get; set; }
    }
}

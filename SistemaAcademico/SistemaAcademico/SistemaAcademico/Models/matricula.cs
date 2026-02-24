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
    }
}

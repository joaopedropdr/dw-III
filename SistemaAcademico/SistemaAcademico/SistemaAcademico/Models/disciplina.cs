namespace SistemaAcademico.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }

        public string? Nome { get; set; }
        public int Semestre {  get; set; }
        // Relacionamento com o curso
        public int CusrsoId { get; set; }
        public Curso? Curso { get; set; }
    }
}

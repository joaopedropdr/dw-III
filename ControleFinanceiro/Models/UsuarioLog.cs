using MongoDB.Bson.Serialization.Attributes;

namespace ControleFinanceiro.Models
{
    public class UsuarioLog
    {
        // Diretivas para evitar erros no mongo
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public int IdMysql { get; set; }
        public string? Acao { get; set; }
        public ICollection<UsuarioLog> DadosAnteriores = new List<UsuarioLog>(); // dados anteriores do usuário ao fazer a ação
        public ICollection<UsuarioLog> DadosNovos = new List<UsuarioLog>(); //  dados novos do usuário ao fazer a ação
        public ICollection<UsuarioLog> Metadados = new List<UsuarioLog>(); //  metadados do usuario, como navegador e ip
        public bool Atividade { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime delete_at { get; set; }

    }
}

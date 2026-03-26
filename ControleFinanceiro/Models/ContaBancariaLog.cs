using MongoDB.Bson.Serialization.Attributes;

namespace ControleFinanceiro.Models
{
    public class ContaBancariaLog
    {
        // Diretivas para evitar erros no mongo
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public int IdMysql { get; set; }
        public string? Acao { get; set; }
        public ICollection<ContaBancariaLog> DadosAnteriores = new List<ContaBancariaLog>(); // dados anteriores do usuário ao fazer a ação
        public ICollection<ContaBancariaLog> DadosNovos = new List<ContaBancariaLog>(); //  dados novos do usuário ao fazer a ação

        public bool Atividade { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime delete_at { get; set; }
    }
}


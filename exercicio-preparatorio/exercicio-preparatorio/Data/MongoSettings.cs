using exercicio_preparatorio.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace exercicio_preparatorio.Data
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool IsSsl { get; set; }
    }
}

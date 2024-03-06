using System.Data.SqlClient;
using System.Xml.Linq;

namespace EvictionCaseFilingAPI.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public XElement GetDataAsXml(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandText = query;

                    using (var reader = command.ExecuteXmlReader())
                    {
                        return XElement.Load(reader);
                    }
                }
            }
        }
    }
}
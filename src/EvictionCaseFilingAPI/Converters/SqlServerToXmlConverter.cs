using System.Data.SqlClient;
using System.Xml;

namespace EvictionCaseFilingAPI.Converters
{
    public static class SqlServerToXmlConverter
    {
        public static string GetDataFromSqlServerAsXml(string connectionString, string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteXmlReader())
                    {
                        var document = new XmlDocument();
                        document.Load(reader);
                        return document.OuterXml;
                    }
                }
            }
        }
    }
}
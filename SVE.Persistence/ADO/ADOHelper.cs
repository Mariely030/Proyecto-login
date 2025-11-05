using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace SVE.Persistence.ADO
{
    public class ADOHelper : IADOHelper
    {
        private readonly string? _connectionString;

        public ADOHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<int> ExecuteAsync(string procedureName, Dictionary<string, object> parameters, MySqlParameter? outputParam = null)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var param in parameters)
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

            if (outputParam != null)
                command.Parameters.Add(outputParam);

            await connection.OpenAsync();
            var result = await command.ExecuteNonQueryAsync();

            return result;
        }

        public async Task<List<T>> QueryAsync<T>(string procedureName, Func<MySqlDataReader, T> map, Dictionary<string, object>? parameters = null)
        {
            var results = new List<T>();
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                foreach (var param in parameters)
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            await connection.OpenAsync();
            using var reader = (MySqlDataReader) await command.ExecuteReaderAsync();


            while (await reader.ReadAsync())
                results.Add(map(reader));

            return results;
        }
    }
}

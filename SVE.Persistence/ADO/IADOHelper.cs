using MySql.Data.MySqlClient;

namespace SVE.Persistence.ADO
{

    public interface IADOHelper
    {

        Task<int> ExecuteAsync(string procedureName, Dictionary<string, object> parameters, MySqlParameter? outputParam = null);
        Task<List<T>> QueryAsync<T>(string procedureName, Func<MySqlDataReader, T> map, Dictionary<string, object>? parameters = null);
    }
}
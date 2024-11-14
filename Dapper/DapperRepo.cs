using Dapper;
using System.Data;

namespace DapperExample.API.Dapper
{
    public class DapperRepo : IDapper
    {
        private readonly IDbConnection _dbConnection;

        public DapperRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await _dbConnection.QueryAsync<T>(sql, param);
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await _dbConnection.ExecuteAsync(sql, param);
        }
    }
}

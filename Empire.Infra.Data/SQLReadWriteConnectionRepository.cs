using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Empire.Infra.Data
{
    public class SQLReadWriteConnectionRepository : IRepository
    {
        private readonly string dbConnectionString;

        public int ConnectionTimeOut => 120;

        public SQLReadWriteConnectionRepository(IConfiguration configuration)
        {
            dbConnectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<T> DBContext<T>(Func<IDbConnection, Task<T>> processQuery)
        {
            using var connection = new SqlConnection(dbConnectionString);
            await connection.OpenAsync();
            return await processQuery(connection);
        }

        public async Task DBContext(Func<IDbConnection, Task> processQuery)
        {
            using var dbConnection = new SqlConnection(dbConnectionString);
            await dbConnection.OpenAsync();
            await processQuery(dbConnection);
        }


        public Task<IEnumerable<T>> GetAll<T>(string procName, object? parameters)
        {
            return DBContext(connection =>
            {
                return connection.QueryAsync<T>(procName,
                    param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionTimeOut);
            });
        }

        public Task<T> GetFirst<T>(string procName, object parameters)
        {
            return DBContext(connection =>
            {
                return connection.QueryFirstAsync<T>(procName,
                    param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionTimeOut);
            });
        }

        public Task<T> GetFirstOrDefault<T>(string procName, object parameters)
        {
            return DBContext(connection =>
            {
                return connection.QueryFirstOrDefaultAsync<T>(procName,
                    param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionTimeOut);
            });
        }

        public Task<int> CreateOrUpdate(string procName, object parameters)
        {
            return DBContext(connection =>
            {
                return connection.ExecuteAsync(procName,
                    param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionTimeOut);
            });
        }

        public Task<T> GetScalarValue<T>(string procName, object parameters)
        {
            return DBContext(connection =>
            {
                return connection.ExecuteScalarAsync<T>(procName,
                    param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionTimeOut);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Infra.Data
{
   public interface IRepository
    {
        int ConnectionTimeOut { get; }

        Task<T> DBContext<T>(Func<IDbConnection, Task<T>> processQuery);

        Task DBContext(Func<IDbConnection, Task> processQuery);

        Task<IEnumerable<T>> GetAll<T>(string procName, object parameters);

        Task<T> GetFirst<T>(string procName, object parameters);

        Task<T> GetFirstOrDefault<T>(string procName, object parameters);

        Task<int> CreateOrUpdate(string procName, object parameters);

        Task<T> GetScalarValue<T>(string procName, object parameters);
    }
}

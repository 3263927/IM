using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface ISqlExecutor
    {
        Task<IEnumerable<ExpandoObject>> ExecuteQueryAsync(string query, ExpandoObject descriptor, ExpandoObject parameters);

        Task<IEnumerable<ExpandoObject>> ExecuteStoredProcedureAsync(string procedureName, ExpandoObject parameters);
    }
}
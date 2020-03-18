using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class SqlExecutor : ISqlExecutor
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public SqlExecutor(intuitContext intuitContext)
        {
            _log = LogManager.GetLogger(typeof(SqlExecutor));
            _intuitContext = intuitContext;
        }

        public async Task<IEnumerable<ExpandoObject>> ExecuteQueryAsync(string query, ExpandoObject descriptor, ExpandoObject parameters)
        {
            var objectResult = new List<ExpandoObject>();
            using (var command = _intuitContext.Database.GetDbConnection().CreateCommand())
            {
                _log.Info($"query - {query}");
                command.CommandText = query;

                foreach (var field in descriptor)
                {
                    command.Parameters.Add(CreateParameter(parameters.SingleOrDefault(x => x.Key.Equals(field.Key)), field));
                }

                _log.Info($"filled query - {command}");

                _intuitContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                    foreach (IDataRecord record in (IEnumerable)reader)
                    {
                        var @object = new ExpandoObject() as IDictionary<string, object>;
                        foreach (var name in names)
                        {
                            @object[name] = record[name];
                        }
                        objectResult.Add((ExpandoObject)@object);
                    }
                }
            }
            _log.Info($"result - {JsonConvert.SerializeObject(objectResult)}");

            return objectResult;
        }

        public async Task<IEnumerable<ExpandoObject>> ExecuteStoredProcedureAsync(string procedureName,
            ExpandoObject parameters)
        {
            var objectResult = new List<ExpandoObject>();
            using (var command = _intuitContext.Database.GetDbConnection().CreateCommand())
            {
                _log.Info($"stored procedure - {procedureName}");
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(new NpgsqlParameter(parameter.Key, parameter.Value));
                }

                _log.Info($"filled query - {command}");

                _intuitContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                    foreach (IDataRecord record in (IEnumerable)reader)
                    {
                        var @object = new ExpandoObject() as IDictionary<string, object>;
                        foreach (var name in names)
                        {
                            @object[name] = record[name];
                        }
                        objectResult.Add((ExpandoObject)@object);
                    }
                }
            }
            _log.Info($"result - {JsonConvert.SerializeObject(objectResult)}");

            return objectResult;
        }

        private NpgsqlParameter CreateParameter(KeyValuePair<string, object> parameter, KeyValuePair<string, object> type)
        {
            switch (type.Value.ToString())
            {
                case "uuid":
                    {
                        return new NpgsqlParameter<Guid>($"@{parameter.Key}", Guid.Parse(parameter.Value.ToString()));
                    }
                case "int":
                    {
                        return new NpgsqlParameter<int>($"@{parameter.Key}", int.Parse(parameter.Value.ToString()));
                    }
                case "str":
                    {
                        return new NpgsqlParameter<string>($"@{parameter.Key}", parameter.Value.ToString());
                    }
                case "dt":
                    {
                        return new NpgsqlParameter<DateTime>($"@{parameter.Key}", DateTime.Parse(parameter.Value.ToString()));
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}

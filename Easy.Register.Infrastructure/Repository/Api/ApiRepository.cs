using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model.Api;
using Dapper;
using Easy.Public;

namespace Easy.Register.Infrastructure.Repository.Api
{
    public class ApiRepository : IApiRepository, IDao
    {
        private readonly EntityPropertyHelper<Model.Api.Api> helper = new EntityPropertyHelper<Model.Api.Api>();

        public void Add(Model.Api.Api[] apiList)
        {
            using (var conn = Database.Open())
            {
                var trans = conn.BeginTransaction();
                try
                {
                    foreach (var item in apiList)
                    {
                        var tuple = ApiSql.Add(item);
                        int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                        helper.SetValue(m => m.Id, item, id);
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }

        public void RemoveAll()
        {
            using (var conn = Database.Open())
            {
                conn.Execute(ApiSql.RemoveAll());
            }
        }

        public IEnumerable<Model.Api.Api> SelectByDirectoryId(int directoryId)
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Api.Api>(ApiSql.FindByDirectoryId(directoryId));
            }
        }
    }
}

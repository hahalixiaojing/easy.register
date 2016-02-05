using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Easy.Domain.RepositoryFramework;
using Easy.Public;
using Easy.Register.Model;

namespace Easy.Register.Infrastructure.Repository.Relationship
{
    public class RelationshipRepository : IRelationshipRepsitory,IDao
    {
        private static Easy.Public.EntityPropertyHelper<Model.Relationship> propertyHelper = new Public.EntityPropertyHelper<Model.Relationship>();

        private Model.Relationship SelectConvert(Model.Relationship r,Model.ConsumerInfo consumerInfo, Model.ProviderInfo providerIdInfo)
        {
            propertyHelper.SetValue(m => m.ConsumerInfo, r, consumerInfo);
            propertyHelper.SetValue(m => m.Provider, r, providerIdInfo);
            return r;
        }

        public void Add(Model.Relationship relationship)
        {
            using (var conn=Database.Open())
            {
                var tuple = RelationshipSql.Add(relationship);
                conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
            }
        }

        public bool RelationIsExists(int providerDirectoryId, int consumerDirectoryId)
        {
            using (var conn=Database.Open())
            {
                var tuple = RelationshipSql.IsExists(consumerDirectoryId, providerDirectoryId);
                var model = conn.Query<Model.Relationship>(tuple.Item1, (object)tuple.Item2);

                if (model.Any())
                {
                    return false;
                }
                return true;
            }
        }

        public void RemoveAll()
        {
            using (var conn=Database.Open())
            {
                conn.Execute(RelationshipSql.RemoveAll());
            }
        }

        public void Remove(int consumerDirectoryId)
        {
            using (var conn=Database.Open())
            {
                conn.Execute(RelationshipSql.Remove(consumerDirectoryId));
            }
        }

        public IEnumerable<Model.Relationship> Select(int consumerDirectoryId)
        {
            using (var conn=Database.Open())
            {
                string sql = RelationshipSql.SelectBy(consumerDirectoryId);
                return conn.Query<Model.Relationship, Model.ConsumerInfo, Model.ProviderInfo, Model.Relationship>(sql, SelectConvert,splitOn:"split");
            }
        }

        public IEnumerable<Model.Relationship> SelectAll()
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Relationship, Model.ConsumerInfo, Model.ProviderInfo, Model.Relationship>(RelationshipSql.FindAll(), SelectConvert, splitOn: "split").ToList();
            }
        }

        public void Add(IList<Model.Relationship> list)
        {
            if(list == null || list.Count == 0)
            {
                return;
            }
            using (var conn = Database.Open())
            {
                var trans = conn.BeginTransaction();
                try
                {
                    string sql = RelationshipSql.Remove(list[0].ConsumerInfo.ConsumerDirectoryId);

                    conn.Execute(sql, trans);

                    foreach (var item in list)
                    {
                        var tuple = RelationshipSql.Add(item);
                        conn.Execute(tuple.Item1, (object)tuple.Item2, trans);
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
              
            }
        }
    }
}


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
                return conn.Query<Model.Relationship>(sql);
            }
        }

        public IEnumerable<Model.Relationship> SelectAll()
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Relationship>(RelationshipSql.FindAll()).ToList();
            }
        }

    }
}


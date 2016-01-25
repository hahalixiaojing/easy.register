using System;
using System.Collections.Generic;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model;
using Dapper;
using System.Linq;

namespace Easy.Register.Infrastructure.Repository.Node
{
    public class NodeRepository : INodeRepository, IDao
    {
        private static Easy.Public.EntityPropertyHelper<Model.Node> propertyHelper = new Public.EntityPropertyHelper<Model.Node>();

        public void Add(Model.Node item)
        {
            using (var conn = Database.Open())
            {
                var tuple = NodeSql.Add(item);

                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                propertyHelper.SetValue<int>(m => m.Id, item, id);
            }
        }

        public IList<Model.Node> FindAll()
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Node>(NodeSql.FindAll()).ToList();
            }
        }

        public Model.Node FindBy(int key)
        {
            using (var conn = Database.Open())
            {
                var tuple = NodeSql.FindById(key);
                return conn.Query<Model.Node, Model.DirectoryInfo, Model.Node>(tuple.Item1, (node, info) =>
                {
                    node.DirectoryInfo = new DirectoryInfo(info.Id, info.Name);
                    return node;
                }, (object)tuple.Item2, splitOn: "split").FirstOrDefault();
            }
        }

        public bool IsExists(Model.Node n)
        {
            using (var conn = Database.Open())
            {
                var tuple = NodeSql.IsExists(n.DirectoryInfo.Id, n.Url);

                var model = conn.Query<Model.Node>(tuple.Item1, (object)tuple.Item2);

                if (model.Any())
                {
                    return false;
                }
                return true;
            }
        }

        public void Remove(Model.Node item)
        {
            using (var conn = Database.Open())
            {
                conn.Execute(NodeSql.Remove(item.Id));
            }
        }

        public void RemoveAll()
        {
            using (var conn = Database.Open())
            {
                conn.Execute(NodeSql.RemoveAll());
            }
        }

        public IEnumerable<Model.Node> Select(DirectoryType directoryType)
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Node, Model.DirectoryInfo, Model.Node>(NodeSql.SelectByDirectoryType(directoryType.GetHashCode()), (node, info) =>
                {
                    node.DirectoryInfo = new DirectoryInfo(info.Id, info.Name);
                    return node;
                }, splitOn: "split");
            }
        }

        public IEnumerable<Model.Node> Select(int directoryId)
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Node>(NodeSql.SelectByDirectoryId(directoryId));
            }
        }

        public void Update(Model.Node item)
        {
            using (var conn = Database.Open())
            {
                var tuple = NodeSql.Update(item);

                conn.ExecuteScalar(tuple.Item1, (object)tuple.Item2);
            }
        }
    }
}

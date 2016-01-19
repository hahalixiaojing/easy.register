using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace Easy.Register.Infrastructure.Repository.Directory
{
    public class DirectoryRepository:Model.IDirectoryRepository,IDao
    {
        private static Easy.Public.EntityPropertyHelper<Model.Directory> propertyHelper = new Public.EntityPropertyHelper<Model.Directory>();

        public Model.Directory FindBy(string name)
        {
            using (var conn = Database.Open())
            {
                var tuple = DirectorySql.FindByName(name);
                return conn.Query<Model.Directory>(tuple.Item1, (object)tuple.Item2).FirstOrDefault();
            }
        }

        public bool DirectoryIsExists(Model.Directory d)
        {
            using (var conn = Database.Open())
            {
                var tuple = DirectorySql.DirectoryIsExists(d.Name, d.Id);
                return conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2) > 0;
            }
        }

        public IEnumerable<Model.Directory> Select(Model.DirectoryType directoryType)
        {
            using (var conn = Database.Open())
            {
                string sql = DirectorySql.SelectDirectoryType(directoryType);
                return conn.Query<Model.Directory>(sql);
            }
        }

        public void Add(Model.Directory item)
        {
            using (var conn = Database.Open())
            {
                var tuple = DirectorySql.Add(item);

                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                propertyHelper.SetValue<int>(m => m.Id, item, id);
            }
        }

        public IList<Model.Directory> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.Directory FindBy(int key)
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.Directory>(DirectorySql.FindById(key)).FirstOrDefault();
            }
        }

        public void Remove(Model.Directory item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            using (var conn = Database.Open())
            {
                conn.Execute(DirectorySql.RemoveAll());
            }
        }

        public void Update(Model.Directory item)
        {
            throw new NotImplementedException();
        }
    }
}

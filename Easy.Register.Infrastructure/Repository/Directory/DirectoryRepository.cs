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
        public Model.Directory FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryIsExists(Model.Directory d)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Directory> Select(Model.DirectoryType directoryType)
        {
            throw new NotImplementedException();
        }

        public void Add(Model.Directory item)
        {
            using (var conn = Database.Open())
            {
                var tuple = DirectorySql.Add(item);

                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
            }
        }

        public IList<Model.Directory> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.Directory FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public void Remove(Model.Directory item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Model.Directory item)
        {
            throw new NotImplementedException();
        }
    }
}

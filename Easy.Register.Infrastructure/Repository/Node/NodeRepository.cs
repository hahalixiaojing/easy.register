using System;
using System.Collections.Generic;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model;

namespace Easy.Register.Infrastructure.Repository.Node
{
    public class NodeRepository : INodeRepository, IDao
    {
        public void Add(Model.Node item)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Node> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.Node FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(Model.Node n)
        {
            throw new NotImplementedException();
        }

        public void Remove(Model.Node item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Node> Select(int directoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Model.Node item)
        {
            throw new NotImplementedException();
        }
    }
}

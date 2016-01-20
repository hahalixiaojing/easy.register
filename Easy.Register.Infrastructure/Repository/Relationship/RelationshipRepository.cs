using System;
using System.Collections.Generic;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model;

namespace Easy.Register.Infrastructure.Repository.Relationship
{
    public class RelationshipRepository : IRelationshipRepsitory,IDao
    {
        public void Add(Model.Relationship relationship)
        {
            throw new NotImplementedException();
        }

        public bool RelationIsExists(int providerDirectoryId, int consumerDirectoryId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveBy(int consumerDirectoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Relationship> Select(int consumerDirectoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Relationship> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}

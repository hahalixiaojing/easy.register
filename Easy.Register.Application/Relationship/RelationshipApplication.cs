using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Relationship;
using Easy.Register.Model;

namespace Easy.Register.Application.Relationship
{
    public  class RelationshipApplication:BaseApplication
    {
        public IEnumerable<Relation> GetRelations()
        {
            return
                RepositoryRegistry.Relationship.SelectAll()
                    .Select(d => new Relation(d.Provider.Name, d.ConsumerInfo.Name));
        }

        public void Add(string Name, int DirectoryId)
        {
            
        }
    }
}

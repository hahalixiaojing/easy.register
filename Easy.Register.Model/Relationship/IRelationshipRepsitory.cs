using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public interface IRelationshipRepsitory
    {
        void Add(Relationship relationship);
        IEnumerable<Relationship> SelectAll();
        IEnumerable<Relationship> Select(string consumer);
    }
}

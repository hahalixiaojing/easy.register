using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public interface INodeRepository : IRepository<Node, Int32>
    {
        IEnumerable<Node> Select(int directoryId);

        bool IsExists(Node n);
    }
}

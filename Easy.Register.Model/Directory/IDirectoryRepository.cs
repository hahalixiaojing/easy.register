using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public interface IDirectoryRepository : IRepository<Directory, Int32>
    {
        Directory FindBy(string name);
        bool DirectoryIsExists(Directory d);
    }
}

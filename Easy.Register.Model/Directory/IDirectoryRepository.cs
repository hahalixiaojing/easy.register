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
        IEnumerable<Directory> FindBy(string[] names);
        bool DirectoryIsExists(Directory d);

        IEnumerable<Directory> Select(DirectoryType directoryType);

        void UpdateUsedServiceMd5(int directoryId, string usedServiceMd5);
        void UpdateServiceApiMd5(int directoryId, string serviceApiMd5);
        void UpdateProviderNodeCount(int directoryId, int providerNodeCount);
    }
}

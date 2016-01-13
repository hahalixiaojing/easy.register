using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public static class RepositoryRegistry
    {
        readonly static RepositoryFactory factory;
        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder b = new RepositoryFactoryBuilder();

            var file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repository.config"));

            factory = b.Build(file);
        }
        public static IDirectoryRepository Directory
        {
            get
            {
                return factory.Get<IDirectoryRepository>();
            }
        }
        public static INodeRepository Node
        {
            get
            {
                return factory.Get<INodeRepository>();
            }
        }
    }
}

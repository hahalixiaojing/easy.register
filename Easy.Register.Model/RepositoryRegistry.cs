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
            Stream stream = Assembly.ReflectionOnlyLoadFrom("Easy.Register.Infrastructure.dll").GetManifestResourceStream("Easy.Register.Infrastructure.Repository.repository.xml");

            factory = b.Build(stream);
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

        public static IRelationshipRepsitory Relationship
        {
            get
            {
                return factory.Get<IRelationshipRepsitory>();
            }
        }

    }
}

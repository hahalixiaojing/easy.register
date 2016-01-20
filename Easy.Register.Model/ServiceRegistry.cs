using System.IO;
using System.Reflection;
using Easy.Domain.ServiceFramework;
using Easy.Register.Model.PublishService;

namespace Easy.Register.Model
{
    public static class ServiceRegistry
    {
        readonly static ServiceFactory factory;

        static ServiceRegistry()
        {
            ServiceFactoryBuilder b = new ServiceFactoryBuilder();
            Stream stream = Assembly.ReflectionOnlyLoadFrom("Easy.Register.Infrastructure.dll").GetManifestResourceStream("Easy.Register.Infrastructure.Service.service.xml");

            factory = b.Build(stream);
        }

        public static IPublishService PublishService
        {
            get
            {
                return factory.Get<IPublishService>();
            }
        }
    }
}

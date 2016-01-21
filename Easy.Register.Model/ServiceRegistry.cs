using System;
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
            string path = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, "Easy.Register.Infrastructure.dll");

            Stream stream = Assembly.ReflectionOnlyLoadFrom(path).GetManifestResourceStream("Easy.Register.Infrastructure.Service.service.xml");

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

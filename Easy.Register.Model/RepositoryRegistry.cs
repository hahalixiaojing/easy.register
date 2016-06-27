﻿using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Easy.Register.Model.User;
using Easy.Register.Model.Api;
using Easy.Register.Model.Profile;

namespace Easy.Register.Model
{
    public static class RepositoryRegistry
    {
        readonly static RepositoryFactory factory;
        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder b = new RepositoryFactoryBuilder();

            string path = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath?? AppDomain.CurrentDomain.BaseDirectory, "Easy.Register.Infrastructure.dll");

            Stream stream = Assembly.ReflectionOnlyLoadFrom(path).GetManifestResourceStream("Easy.Register.Infrastructure.Repository.repository.xml");

            factory = b.Build(stream);
        }

        /// <summary>
        /// 应用程序配置文件
        /// </summary>
        public static IApplicationProfileRepository ApplicationProfile
        {
            get
            {
                return factory.Get<IApplicationProfileRepository>();
            }
        }

        public static IApiRepository Api
        {
            get
            {
                return factory.Get<IApiRepository>();
            }
        }
        public static IUserRepository User
        {
            get
            {
                return factory.Get<IUserRepository>();
            }
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

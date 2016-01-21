using Easy.Domain.Application;
using Easy.Register.Application.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Register.Application.Relationship;

namespace Easy.Register.Application
{
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new DirectoryApplication());
            ApplicationFactory.Instance().Register(new RelationshipApplication());
        }
        public static DirectoryApplication Directory
        {
            get
            {
                return ApplicationFactory.Instance().Get<DirectoryApplication>();
            }
        }

        public static RelationshipApplication Relationship
        {
            get { return ApplicationFactory.Instance().Get<RelationshipApplication>(); }
        }
    }
}

using Easy.Domain.Application;
using Easy.Register.Application.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application
{
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new DirectoryApplication());
        }
        public static DirectoryApplication Directory
        {
            get
            {
                return ApplicationFactory.Instance().Get<DirectoryApplication>();
            }
        }
    }
}

using Easy.Domain.Application;
using Easy.Register.Application.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Register.Application.Node;

namespace Easy.Register.Application
{
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new DirectoryApplication());
            ApplicationFactory.Instance().Register(new NodeApplication());
        }
        public static DirectoryApplication Directory
        {
            get
            {
                return ApplicationFactory.Instance().Get<DirectoryApplication>();
            }
        }
        public static NodeApplication Node
        {
            get
            {
                return ApplicationFactory.Instance().Get<NodeApplication>();
            }
        }
        
    }
}

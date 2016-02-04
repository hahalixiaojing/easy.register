using Easy.Domain.Application;
using Easy.Register.Application.Directory;
using Easy.Register.Application.Relationship;
using Easy.Register.Application.Node;
using Easy.Register.Application.User;

namespace Easy.Register.Application
{
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new DirectoryApplication());
            ApplicationFactory.Instance().Register(new RelationshipApplication());
            ApplicationFactory.Instance().Register(new NodeApplication());
            ApplicationFactory.Instance().Register(new UserApplication());
        }

        public static UserApplication User {

            get
            {
                return ApplicationFactory.Instance().Get<UserApplication>();
            }
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
            get
            {
                return ApplicationFactory.Instance().Get<RelationshipApplication>();
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

﻿using Easy.Domain.Application;
using Easy.Register.Application.Directory;
using Easy.Register.Application.Relationship;
using Easy.Register.Application.Node;
using Easy.Register.Application.User;
using Easy.Register.Application.Profile;

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
            ApplicationFactory.Instance().Register(new ApiApplication());
            ApplicationFactory.Instance().Register(new ProfileApplication());
        }
        public static ProfileApplication Profile
        {
            get
            {
                return ApplicationFactory.Instance().Get<ProfileApplication>();
            }
        }
        public static ApiApplication Api
        {
            get
            {
                return ApplicationFactory.Instance().Get<ApiApplication>();
            }
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

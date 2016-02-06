using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Easy.Public.MvcSecurity;

namespace Easy.Register.Utility
{
    public static class UserSession
    {
        public static string User
        {
            get
            {
                var user = HttpContext.Current.User as AuthenticateUser;
                return user.UserData;
            }
        }
    }

}
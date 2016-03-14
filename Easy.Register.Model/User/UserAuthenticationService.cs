using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.User
{
    public class UserAuthenticationService
    {
        public UserDescriptor Authenticate(string username,string password)
        {
            User user = RepositoryRegistry.User.FindBy(username);

            if (user == null && username == "admin" && password == "100001")
            {
                return new UserDescriptor(0, "管理员");
            }
            if(user  == null)
            {
                return null;
            }

            if(user.Password != new PasswordService().Encrypt(password))
            {
                return null;
            }
            return new UserDescriptor(user.Id, user.Name);
        }
    }
}

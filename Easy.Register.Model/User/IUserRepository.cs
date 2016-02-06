using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;

namespace Easy.Register.Model.User
{
    public interface IUserRepository : IRepository<User, int>
    {
        bool UsernameIsExists(string usrname, int currentUserId);
        User FindBy(string username);
    }
}

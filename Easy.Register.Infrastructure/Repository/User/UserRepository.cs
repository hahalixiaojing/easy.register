using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model.User;

namespace Easy.Register.Infrastructure.Repository.User
{
    public class UserRepository : IUserRepository,IDao
    {
        public void Add(Model.User.User item)
        {
            throw new NotImplementedException();
        }

        public IList<Model.User.User> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.User.User FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public void Remove(Model.User.User item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Model.User.User item)
        {
            throw new NotImplementedException();
        }

        public bool UsernameIsExists(string usrname, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model.User;
using Dapper;

namespace Easy.Register.Infrastructure.Repository.User
{
    public class UserRepository : IUserRepository,IDao
    {
        private static readonly Easy.Public.EntityPropertyHelper<Model.User.User> helper = new Public.EntityPropertyHelper<Model.User.User>();

        public void Add(Model.User.User item)
        {
            using (var conn = Database.Open())
            {
                var tuple = UserSql.Add(item);
                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                helper.SetValue(m => m.Id, item, id);
            }
        }

        public IList<Model.User.User> FindAll()
        {
            using (var conn = Database.Open())
            {
                return conn.Query<Model.User.User>(UserSql.FindAll()).ToArray();
            }
        }

        public Model.User.User FindBy(string username)
        {
            using (var conn = Database.Open())
            {
                var tuple = UserSql.FindByName(username);
                return conn.Query<Model.User.User>(tuple.Item1, (object)tuple.Item2).FirstOrDefault();
            }   
        }

        public Model.User.User FindBy(int key)
        {
            using (var con = Database.Open())
            {
                return con.Query<Model.User.User>(UserSql.FindById(key)).FirstOrDefault();
            }
        }

        public void Remove(Model.User.User item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            using (var conn = Database.Open())
            {
                conn.Execute(User.UserSql.RemoveAll());
            }
        }

        public void Update(Model.User.User item)
        {
            using (var conn = Database.Open())
            {
                var tuple = UserSql.Update(item);
                conn.Execute(tuple.Item1, (object)tuple.Item2);
            }
        }

        public bool UsernameIsExists(string usrname, int currentUserId)
        {
            using (var conn = Database.Open())
            {
                return conn.ExecuteScalar<int>(UserSql.UsernameIsExists(currentUserId, usrname)) > 0;
            }
        }
    }
}

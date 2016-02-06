using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Repository.User
{
    static class UserSql
    {
        private static string BaseSelectSql()
        {
            return @"SELECT id as Id, username as Username, name as Name, create_date as CreateDate, password as Password
                    FROM register_user";
        }

        public static string FindAll()
        {
            return string.Join(" ", BaseSelectSql(), " order by id desc");
        }

        public static Tuple<string,dynamic> FindByName(string username)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE username=@Username");

            return new Tuple<string, dynamic>(sql, new
            {
                Username = username
            });
        }

        public static Tuple<string,dynamic> Update(Model.User.User user)
        {
            const string sql = @"UPDATE register_user
	                            SET
		                            username=@Username,
		                            name=@Name,
		                            password=@Password
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, new
            {
                Username = user.Username,
                Name = user.Name,
                Password = user.Password,
                Id=user.Id
            });
        }

        public static string UsernameIsExists(int currentUserid, string username)
        {
            string sql = "SELECT COUNT(*) FROM register_user WHERE id!=" + currentUserid + " and username='" + username + "'";
            return sql;    
        }

        public static string FindById(int userId)
        {
            return string.Join(" ", BaseSelectSql(), "WHERE id=" + userId);
        }

        public static string RemoveAll()
        {
            return "delete from register_user";
        }

        public static Tuple<string,dynamic> Add(Model.User.User user)
        {
            const string sql = @"INSERT INTO register_user
                                (username, name, create_date, password)
                                VALUES(@UserName, @Name, @CreateDate, @Password);select last_insert_id()";

            return new Tuple<string, dynamic>(sql,new {

                UserName=user.Username,
                Name=user.Name,
                CreateDate=user.CreateDate,
                Password= user.Password
            });
        }
    }
}

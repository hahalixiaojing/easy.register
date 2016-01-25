using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Repository.Directory
{
    static class DirectorySql
    {
        static string BaseSelectSql()
        {
            return @"SELECT id as Id, name as Name, description as Description, ping_api_path as        PingAPIPath, version_api_path as VersionAPIPath, create_date as CreateDate,directory_type as DirectoryType
	            FROM regisrer_directory";
        }

        public static string FindByNames(string[] names)
        {
            string namestr = "'" + string.Join("','", names) + "'";
            return string.Join(" ", BaseSelectSql(), string.Format("WHERE name IN({0})", namestr));
        }

        public static Tuple<string, dynamic> DirectoryIsExists(string name, int id)
        {
            string sql = "select count(*) from regisrer_directory where name=@Name and id !=@Id";
            return new Tuple<string, dynamic>(sql, new
            {
                Name = name,
                Id = id
            });
        }

        public static string FindAll()
        {
            return string.Join(" ", BaseSelectSql(), "order by CreateDate desc");
        }


        public static string SelectDirectoryType(Model.DirectoryType type)
        {
            return string.Join(" ", BaseSelectSql(), "WHERE directory_type=3 or directory_type=" + (int)type);
        }
        public static string FindById(int id)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "id=" + id);
            return sql;
        }
        public static Tuple<string, dynamic> FindByName(string name)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "name=@Name");

            return new Tuple<string, dynamic>(sql, new { Name = name });
        }

        public static string RemoveAll()
        {
            return "delete from regisrer_directory";
        }

        public static string Remove(int id)
        {
            return string.Join(" ", RemoveAll(), "WHERE id=" + id);
        }

        public static Tuple<string,dynamic> Update(Model.Directory directory)
        {
            string sql = @"UPDATE regisrer_directory
                    SET
                        description = @Description,
                        ping_api_path = @PingApiPath,
                        version_api_path = @VersionApiPath,
                        directory_type = @DirectoryType
                    WHERE id = @Id";


            return new Tuple<string, dynamic>(sql, new
            {
                Description = directory.Description,
                PingApiPath = directory.PingAPIPath,
                VersionApiPath = directory.VersionAPIPath,
                DirectoryType = directory.DirectoryType,
                Id = directory.Id
            });
        }

        public static Tuple<string, dynamic> Add(Model.Directory directory)
        {
            const string sql = @"INSERT INTO regisrer_directory
	                            (name, description, ping_api_path, version_api_path, create_date,directory_type)
	                            VALUES (@Name, @Desc, @PingApiPath, @VersionApiPath, @Date,@DirectoryType);SELECT last_insert_id()";


            return new Tuple<string, dynamic>(sql, new
            {
                Name = directory.Name,
                Desc = directory.Description,
                PingApiPath = directory.PingAPIPath,
                VersionApiPath = directory.VersionAPIPath,
                Date = directory.CreateDate,
                DirectoryType = directory.DirectoryType
            });
        }
    }
}

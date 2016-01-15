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
            return @"SELECT id as Id, name as Name, description as Description, ping_api_path as        VersionAPIPath, version_api_path as VersionAPIPath, create_date as CreateDate,directory_type as DirectoryType
	            FROM regisrer_directory";
        }
        public static string SelectDirectoryType(Model.DirectoryType type)
        {
            return string.Join(" ", BaseSelectSql(), "WHERE directory_type=" + (int)type);
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

        public static Tuple<string, dynamic> Add(Model.Directory directory)
        {
            const string sql = @"INSERT INTO regisrer_directory
	                            (name, description, ping_api_path, version_api_path, create_date)
	                            VALUES (@Name, @Desc, @PingApiPath, @VersionApiPath, @Date);SELECT last_insert_id()";


            return new Tuple<string, dynamic>(sql, new
            {
                Name = directory.Name,
                Desc = directory.Description,
                PingApiPath = directory.PingAPIPath,
                VersionApiPath = directory.VersionAPIPath,
                Date = directory.CreateDate
            });
        }
    }
}

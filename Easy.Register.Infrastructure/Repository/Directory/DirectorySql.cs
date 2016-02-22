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
            return @"SELECT id as Id, name as Name, 
                    description as Description, ping_api_path as PingAPIPath, 
                    version_api_path as VersionAPIPath, create_date as CreateDate,
                    directory_type as DirectoryType,use_services_md5 as UsedServiceMd5,api_list_md5 as SerivceApiMd5
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
	                            (name, description, ping_api_path, version_api_path, create_date,directory_type,use_services_md5,api_list_md5)
	                            VALUES (@Name, @Desc, @PingApiPath, @VersionApiPath, @Date,@DirectoryType,@UseServiceMd5,@ApiListM5);SELECT last_insert_id()";


            return new Tuple<string, dynamic>(sql, new
            {
                Name = directory.Name,
                Desc = directory.Description,
                PingApiPath = directory.PingAPIPath,
                VersionApiPath = directory.VersionAPIPath,
                Date = directory.CreateDate,
                DirectoryType = directory.DirectoryType,
                UseServiceMd5 = directory.UsedServiceMd5,
                ApiListM5 = directory.SerivceApiMd5
            });
        }


        public static string UpdateUpdateUsedServiceMd5(int directoryId,string usedServcieMd5)
        {
            return "UPDATE regisrer_directory SET use_services_md5='" + usedServcieMd5 + "' WHERE id=" + directoryId;
        }

        public static string UpdateServiceApiMd5(int directoryId,string serviceApiMd5)
        {
            return "UPDATE regisrer_directory SET api_list_md5='" + serviceApiMd5 + "' WHERE id=" + directoryId;
        }

        public static string UpdateProviderNodeCount(int directoryId, int providerNodeCount)
        {
            return "UPDATE regisrer_directory SET provider_node_count=" + providerNodeCount + " WHERE id=" + directoryId;
        }
        
    }
}

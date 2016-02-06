using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Repository.Api
{
    static class ApiSql
    {
        internal static Tuple<string,dynamic> Add(Model.Api.Api api)
        {
            const string sql = @"INSERT INTO register_apis
	                            (api_name, directory_id,directory_name)
	                            VALUES (@ApiName, @DirectoryId,@DirectoryName);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new {
                ApiName = api.Name,
                DirectoryId = api.DirectoryId,
                DirectoryName = api.DirectoryName
            });
        }

        internal static string FindByDirectoryId(int directoryId)
        {
            return @"SELECT id as Id, api_name as Name, directory_id as DirectoryId,directory_name as DirectoryName
                    FROM register_apis";
        }

        internal static string RemoveAll()
        {
            return "delete from register_apis";
        }

        internal static string Remove(int directoryId)
        {
            return "DELETE FROM register_apis WHERE directory_id=" + directoryId;
        }
    }
}

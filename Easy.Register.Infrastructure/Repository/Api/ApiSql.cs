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
	                            (api_name, directory_id)
	                            VALUES (@ApiName, @DirectoryId);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new {
                ApiName = api.Name,
                DirectoryId = api.DirectoryId
            });
        }

        internal static string FindByDirectoryId(int directoryId)
        {
            return @"SELECT id as Id, api_name as Name, directory_id as DirectoryId
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

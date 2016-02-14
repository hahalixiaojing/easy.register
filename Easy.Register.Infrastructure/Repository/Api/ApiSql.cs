using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;
using Easy.Register.Model.Api;

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

        internal static string BaseSelectSql()
        {
            return @"SELECT id as Id, api_name as Name, directory_id as DirectoryId,directory_name as DirectoryName
                    FROM register_apis";
        }

        internal static string FindByDirectoryId(int directoryId)
        {
            return string.Join(" ", BaseSelectSql(), "WHERE", "directory_id=" + directoryId);
        }

        internal static string WhereSql(Query query)
        {
            SQLBuilder builder = new SQLBuilder();

            builder.AppendWhere();
            builder.Append(query.DirectoryId > 0, "and", "directory_id=@DirectoryId");
            builder.Append(!string.IsNullOrWhiteSpace(query.Name), "and", "api_name like '%" + query.Name + "%'");

            return builder.Sql();
        }

        internal static Tuple<string,dynamic> SelectByQuery(Query query)
        {
            string whereSql = WhereSql(query);
            string countSql = string.Join(" ", "select count(*) Count from register_apis", whereSql + ";");
            string dataSql = string.Join(" ", BaseSelectSql(), whereSql, string.Format("limit {0} offset {1};", query.PageSize, (query.PageIndex - 1) * query.PageSize));

            return new Tuple<string, dynamic>(countSql + dataSql, new
            {
                DirectoryId = query.DirectoryId
            });
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

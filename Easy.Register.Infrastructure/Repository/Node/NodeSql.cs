using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Repository.Node
{
    static class NodeSql
    {
        static string BaseSelectSql()
        {
            return @"SELECT id, url, ip, description, weight, `status`, create_date, directory_id, directory_name
	FROM register_node";
        }

        public static Tuple<string, dynamic> Add(Model.Node item)
        {
            const string sql = @"INSERT INTO register_node
	(url, ip, description, weight, `status`, create_date, directory_id, directory_name)
	VALUES (@url, @ip, @description, @weight, @status, @create_date, @directory_id, @directory_name);SELECT last_insert_id()";


            return new Tuple<string, dynamic>(sql, new
            {
                url = item.Url,
                ip = item.Ip,
                description = item.Description,
                weight = item.Weight,
                status = item.Status,
                create_date = item.CreateDate,
                directory_id = item.DirectoryInfo.Id,
                directory_name = item.DirectoryInfo.Name
            });
        }

        public static Tuple<string, dynamic> Update(Model.Node item)
        {
            string sql = @"UPDATE register_node
	                SET
		                url=@url,
		                ip=@ip,
		                description=@description,
		                weight=@weight,
		                `status`=@status,
		                create_date=@create_date,
		                directory_id=@directory_id,
		                directory_name=@directory_name
                    WHERE id = @Id";


            return new Tuple<string, dynamic>(sql, new
            {
                Id = item.Id,
                url = item.Url,
                ip = item.Ip,
                description = item.Description,
                weight = item.Weight,
                status = item.Status,
                create_date = item.CreateDate,
                directory_id = item.DirectoryInfo.Id,
                directory_name = item.DirectoryInfo.Name
            });
        }

        public static string RemoveAll()
        {
            return "delete from register_node";
        }

        public static string Remove(int id)
        {
            return string.Join(" ", RemoveAll(), "WHERE id=" + id);
        }

        public static string FindById(int id)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "id=" + id);
            return sql;
        }

        public static string FindAll()
        {
            return BaseSelectSql();
        }

        public static Tuple<string, dynamic> IsExists(int directiory_id, string url)
        {
            string sql = string.Join(" ", BaseSelectSql(), "where directory_id=@directory_id and url=@url");
            return new Tuple<string, dynamic>(sql, new
            {
                directory_id = directiory_id,
                url = url
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Repository.Directory
{
    static class DirectorySql
    {
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

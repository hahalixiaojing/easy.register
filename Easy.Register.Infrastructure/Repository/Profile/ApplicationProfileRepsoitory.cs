using System;
using System.Collections.Generic;
using Easy.Register.Model;
using Dapper;
using Easy.Public;
using System.Linq;
using Easy.Domain.RepositoryFramework;
using Easy.Register.Model.Profile;

namespace Easy.Register.Infrastructure.Repository.Profile
{
    public class ApplicationProfileRepsoitory : IApplicationProfileRepository,IDao
    {
        private readonly EntityPropertyHelper<ApplicationProfile> helper = new EntityPropertyHelper<ApplicationProfile>();

        private const string BaseSelect = @"SELECT Id, ApplicationName, ProfileName, ContentType, CreateDate,                                             LastUpdate, Content FROM regiser_profile";

        public void Add(ApplicationProfile profile)
        {
            using (var conn = Database.Open())
            {
                string sql = @"INSERT INTO regiser_profile
	                            (ApplicationName, ProfileName, ContentType, CreateDate, LastUpdate, Content)
	                            VALUES (@ApplicationName, @ProfileName, @ContentType, @CreateDate, @LastUpdate, @Content);select last_insert_id()";

                int result = conn.ExecuteScalar<int>(sql, profile);
                helper.SetValue(m => m.Id, profile, result);
            }
        }

        public ApplicationProfile FindBy(int id)
        {
            using (var conn=Database.Open())
            {
                string sql = string.Join(" ", BaseSelect, "WHERE Id=" + id);

                return conn.Query<ApplicationProfile>(new CommandDefinition(sql, flags: CommandFlags.Buffered | CommandFlags.NoCache)).FirstOrDefault();
            }
        }

        public void RemoveAll()
        {
            using(var conn = Database.Open())
            {
                conn.Execute("delete from regiser_profile");
            }
        }

        public IEnumerable<ApplicationProfile> Select()
        {
            using (var conn = Database.Open())
            {
                string sql = string.Join(" ", BaseSelect, "ORDER BY ApplicationName ASC");
                return conn.Query<ApplicationProfile>(sql);
            }
        }

        public void Update(ApplicationProfile profile)
        {
            using (var conn = Database.Open())
            {
                string sql = "UPDATE regiser_profile SET LastUpdate =@LastUpdate, Content =@Content WHERE Id =@Id";

                conn.Execute(sql, new { LastUpdate = profile.LastUpdate, Content = profile.Content, Id = profile.Id });
            }
        }
    }
}

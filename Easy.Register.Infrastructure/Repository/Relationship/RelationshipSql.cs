using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Repository.Relationship
{
    static class RelationshipSql
    {
        private static string BaseSelectSql()
        {
            return @"select consumer_id,consumer_name,provider_id,provider_name from register_relation";
        }

        public static Tuple<string, dynamic> Add(Model.Relationship item)
        {
            const string sql = @"insert into register_relation(consumer_id,consumer_name,provider_id,provider_name) 
                                values (@consumer_id,@consumer_name,@provider_id,@provider_name)";
            return new Tuple<string, dynamic>(sql,new
            {
                consumer_id=item.ConsumerInfo.DirectoryId,
                consumer_name=item.ConsumerInfo.Name,
                provider_id=item.Provider.DirectoryId,
                provider_name=item.Provider.Name
            });
        }

        public static Tuple<string, dynamic> Update(Model.Relationship item)
        {
            string sql = "update register_relation set consumer_id=@consumer_id,consumer_name=@consumer_name,provider_id=@provider_id,provider_name=@provider_name where id=@id";

            return new Tuple<string, dynamic>(sql,new
            {
                consumer_id=item.ConsumerInfo.DirectoryId,
                consumer_name=item.ConsumerInfo.Name,
                provider_id=item.Provider.DirectoryId,
                provider_name=item.Provider.Name
            });
        }

        public static string RemoveAll()
        {
            return "delete from register_relation";
        }

        public static string Remove(int id)
        {
            return string.Join(" ", RemoveAll(), "where consumer_id=" + id);
        }

        public static string FindById(int id)
        {
            return string.Join(" ", BaseSelectSql(), "where", "consumer_id=" + id);
        }

        public static string FindAll()
        {
            return BaseSelectSql();
        }

        public static Tuple<string,dynamic> IsExists(int consumerId, int providerId)
        {
            string sql = string.Join(" ", BaseSelectSql(), "where", "consumer_id=@consumerId and provider_id=@providerId");
            return new Tuple<string, dynamic>(sql,new
            {
                consumerId=consumerId,
                providerId=providerId
            });
        }

        public static string SelectBy(int consumerId)
        {
            return string.Join(" ", BaseSelectSql(), "where", "consumer_id="+consumerId);
        }
    }
}

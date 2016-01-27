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
            return @"select id as Id,create_date as CreateDate,1 as split, consumer_name as ConsumerName,consumer_id as ConsumerDirectoryId,'x' as split ,provider_name as ProviderName,provider_id as ProviderDirectoryId from register_relation";
        }

        public static Tuple<string, dynamic> Add(Model.Relationship item)
        {
            const string sql = @"insert into register_relation(consumer_id,consumer_name,provider_id,provider_name,create_date) 
                                values (@consumer_id,@consumer_name,@provider_id,@provider_name,@CreateDate)";
            return new Tuple<string, dynamic>(sql, new
            {
                consumer_id = item.ConsumerInfo.ConsumerDirectoryId,
                consumer_name = item.ConsumerInfo.ConsumerName,
                provider_id = item.Provider.ProviderDirectoryId,
                provider_name = item.Provider.ProviderName,
                CreateDate = item.CreateDate
            });
        }

        public static Tuple<string, dynamic> Update(Model.Relationship item)
        {
            string sql = "update register_relation set consumer_id=@consumer_id,consumer_name=@consumer_name,provider_id=@provider_id,provider_name=@provider_name where id=@id";

            return new Tuple<string, dynamic>(sql, new
            {
                consumer_id = item.ConsumerInfo.ConsumerDirectoryId,
                consumer_name = item.ConsumerInfo.ConsumerName,
                provider_id = item.Provider.ProviderDirectoryId,
                provider_name = item.Provider.ProviderName
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

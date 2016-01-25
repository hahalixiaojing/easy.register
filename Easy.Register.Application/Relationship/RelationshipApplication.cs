using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Relationship;
using Easy.Register.Model;

namespace Easy.Register.Application.Relationship
{
    public class RelationshipApplication : BaseApplication
    {
        public IEnumerable<Relation> GetRelations()
        {
            return
                RepositoryRegistry.Relationship.SelectAll()
                    .Select(d => new Relation(d.Provider.Name, d.ConsumerInfo.Name));
        }
        /// <summary>
        /// 添加关系
        /// </summary>
        /// <param name="consumerDirectoryName"></param>
        /// <param name="providerDirectoryName"></param>
        public void AddRelation(string consumerDirectoryName, string[] providerDirectoryName)
        {
            var consumerDirectory = RepositoryRegistry.Directory.FindBy(consumerDirectoryName);
            if(consumerDirectory == null)
            {
                return;
            }

            var providerDirectorys = RepositoryRegistry.Directory.FindBy(providerDirectoryName);

            var list = new List<Model.Relationship>();
            foreach (var item in providerDirectorys)
            {
                var consumerInfo = new ConsumerInfo(consumerDirectory.Name, consumerDirectory.Id);
                var providerInfo = new ProviderInfo(item.Name, item.Id);
                var relationship = new Model.Relationship(consumerInfo, providerInfo);
                list.Add(relationship);
            }
            RepositoryRegistry.Relationship.Add(list);
        }
    }
}

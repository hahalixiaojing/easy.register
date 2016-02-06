using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Application.Api.UpdateApiListDomainEvents;
using Easy.Register.Model.Api;

namespace Easy.Register.Application
{
    public class ApiApplication : BaseApplication
    {
        public void UpdateApiList(Models.Api.Api[] apiList)
        {
            if(apiList == null || apiList.Length == 0)
            {
                return;
            }

            var directory = Model.RepositoryRegistry.Directory.FindBy(apiList[0].DirectoryId);
            if(directory == null)
            {
                return;
            }
            string newMd5;
            var isSame = new ApiListCheckService().IsSame(apiList.Select(m => m.Name).ToArray(), directory.SerivceApiMd5, out newMd5);
            if (isSame)
            {
                return;
            }

            var modelApiList = apiList.Select(m => new Model.Api.Api(m.Name, m.DirectoryId, directory.Name));
            Model.RepositoryRegistry.Api.Add(modelApiList.ToArray());

            this.PublishEvent("UpdateApiList", new UpdateMD5DomainEvent(directory.Id, newMd5));
        }
    }
}

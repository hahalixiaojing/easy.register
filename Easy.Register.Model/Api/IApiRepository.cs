using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.Api
{
    public interface IApiRepository
    {
        void Add(Api[] apiList);
        IEnumerable<Api> SelectByDirectoryId(int directoryId);
        IEnumerable<Api> SelectByQuery(Query query, out int totalRows);
        void RemoveAll();
    }
}

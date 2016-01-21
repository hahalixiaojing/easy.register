using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.PublishService
{
    public interface IPublishService
    {
        /// <summary>
        /// 发布更新Node节点信息
        /// </summary>
        /// <param name="directoryName"></param>
        /// <param name="nodes"></param>
        void Publish(string directoryName, IList<Node> nodes);

        void Subscribe(string directoryName,Action<string,string> action);
    }
}

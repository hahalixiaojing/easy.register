using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Models.Node
{
    public static class NodeExtension
    {
        public static Node Convert(this Model.Node node)
        {
            return new Easy.Register.Application.Models.Node.Node(node.Id, node.DirectoryInfo.Id, node.DirectoryInfo.Name, node.Ip, node.Url, node.Weight, node.Status == Model.NodeStatus.在线, node.Description);
        }
    }
}

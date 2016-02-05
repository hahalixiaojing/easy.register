using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public.Security.Cryptography;

namespace Easy.Register.Model
{
    /// <summary>
    /// 检查引用的服务是否发生了变化
    /// </summary>
    public class RelationShipCheckService
    {
        public bool IsSame(string[] usedSerivce, string originalMd5, out string newMd5)
        {
            var orderedList = usedSerivce.OrderBy(m => { return m.ToUpper(); });
            newMd5 = MD5Helper.Encrypt(string.Concat(orderedList));

            return newMd5 == originalMd5;
        }
    }
}

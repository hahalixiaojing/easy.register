using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Easy.Register.Model;

namespace Easy.Register.Test.Service.Relationship
{
    public class RelationShipCheckServiceTest
    {
        [Test]
        public void IsSameCheckTest()
        {
            var ser = new RelationShipCheckService();

            string[] usedService = { "axx", "order", "abx" };

            string newMd5;
            bool result = ser.IsSame(usedService, string.Empty, out newMd5);

            Assert.IsFalse(result);

            result = ser.IsSame(usedService, newMd5, out newMd5);
            Assert.IsTrue(result);


        }
    }
}

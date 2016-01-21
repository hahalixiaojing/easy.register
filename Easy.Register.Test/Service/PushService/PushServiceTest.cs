using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Easy.Register.Test.Service.PushService
{
    public class PushServiceTest
    {
        [Test]
        public void PushTest()
        {
            Model.ServiceRegistry.PublishService.Subscribe("dsf", (c, s) =>
            {
                Assert.AreEqual("[]", s);
                Assert.AreEqual("dsf", c);
            });
            Model.ServiceRegistry.PublishService.Publish("dsf", new List<Model.PublishService.Node>());

            

            Thread.Sleep(2000);
        }
    }
}

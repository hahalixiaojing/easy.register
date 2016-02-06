using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Easy.Register.Test.Repository.Api
{
    public class ApiRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var api = new Model.Api.Api("paht/adfd", 1,"dd");
            Model.RepositoryRegistry.Api.Add(new Model.Api.Api[1] { api });

            Assert.IsTrue(api.Id > 0);

            var list = Model.RepositoryRegistry.Api.SelectByDirectoryId(api.DirectoryId);

            Assert.IsTrue(list.Count() > 0);
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Api.RemoveAll();
        }
    }
}

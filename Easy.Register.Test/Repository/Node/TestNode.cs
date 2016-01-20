using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Test.Repository.Node
{
    public class TestNode
    {
        [Test]
        public void test_add()
        {
            Model.DirectoryInfo d = new Model.DirectoryInfo(111, "bbb");
            Model.Node n = new Model.Node(d);

            Model.RepositoryRegistry.Node.Add(n);

            var actual = Model.RepositoryRegistry.Node.FindBy(n.Id);

        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Node.RemoveAll();
        }


        void DirectoryAssert(Model.Node expected, Model.Node actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.DirectoryInfo, actual.DirectoryInfo);
            Assert.AreEqual(expected.Ip, actual.Ip);
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.Url, actual.Url);
            Assert.AreEqual(expected.Weight, actual.Weight);
        }
    }
}

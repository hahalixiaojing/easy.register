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

            NodeAssert(n, actual);
        }

        [Test]
        public void test_update()
        {
            Model.DirectoryInfo d = new Model.DirectoryInfo(111, "bbb");
            Model.Node n = new Model.Node(d);

            Model.RepositoryRegistry.Node.Add(n);

            n.Ip = "111";
            n.Url = "url";

            Model.RepositoryRegistry.Node.Update(n);

            var actual = Model.RepositoryRegistry.Node.FindBy(n.Id);

            NodeAssert(n, actual);
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Node.RemoveAll();
        }


        void NodeAssert(Model.Node expected, Model.Node actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.DirectoryInfo.Id, actual.DirectoryInfo.Id);
            Assert.AreEqual(expected.DirectoryInfo.Name, actual.DirectoryInfo.Name);
            Assert.AreEqual(expected.Ip, actual.Ip);
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.Url, actual.Url);
            Assert.AreEqual(expected.Weight, actual.Weight);
        }
    }
}

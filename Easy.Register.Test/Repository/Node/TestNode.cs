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
        public void FindByIdsTest()
        {
            Model.DirectoryInfo d = new Model.DirectoryInfo(111, "bbb");
            Model.Node n = new Model.Node(d);
            Model.Node n2 = new Model.Node(d);

            Model.RepositoryRegistry.Node.Add(n);
            Model.RepositoryRegistry.Node.Add(n2);

            var list = Model.RepositoryRegistry.Node.FindByIds(new int[2] { n.Id, n2.Id });

            Assert.IsTrue(list.Count() > 0);
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
        [Test]
        public void SelectTest()
        {
            var directory = Directory.DirectoryRepositoryTest.Create(Model.DirectoryType.提供者);
            Model.RepositoryRegistry.Directory.Add(directory);

            Model.Node n = new Model.Node(new Model.DirectoryInfo(directory.Id, directory.Name));
            n.Ip = "111";
            n.Url = "url";
            Model.RepositoryRegistry.Node.Add(n);

            var list = Model.RepositoryRegistry.Node.Select(Model.DirectoryType.提供者);
            Assert.IsTrue(list.Count() == 1);

            list = Model.RepositoryRegistry.Node.Select(Model.DirectoryType.消费者);
            Assert.IsTrue(list.Count() == 0);

            list = Model.RepositoryRegistry.Node.Select(directory.Id);
            Assert.IsTrue(list.Count() == 1);
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Node.RemoveAll();
            Model.RepositoryRegistry.Directory.RemoveAll();
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

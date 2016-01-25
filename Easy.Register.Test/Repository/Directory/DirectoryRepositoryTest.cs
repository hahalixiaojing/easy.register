using System.Linq;
using NUnit.Framework;
namespace Easy.Register.Test.Repository.Directory
{

    public class DirectoryRepositoryTest
    {
        [Test]
        public void AddTest()
        {

            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            Assert.IsTrue(expected.Id > 0);

            var actual = Model.RepositoryRegistry.Directory.FindBy(expected.Id);

            DirectoryAssert(expected, actual);
        }
        [Test]
        public void DirectoryIsExistsTest()
        {
            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            var result  = Model.RepositoryRegistry.Directory.DirectoryIsExists(expected);
            Assert.IsFalse(result);
        }
        [Test]
        public void FindAllTest()
        {
            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            var list =  Model.RepositoryRegistry.Directory.FindAll();
            Assert.IsTrue(list.Count > 0);
        }
        [Test]
        public void FindByNamesTest()
        {
            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            var list = Model.RepositoryRegistry.Directory.FindBy(new string[1] { expected.Name });
            Assert.IsTrue(list.Count() > 0);

            list = Model.RepositoryRegistry.Directory.FindBy(new string[1] { "xxoo" });
            Assert.IsTrue(list.Count() == 0);
        }

        [Test]
        public void SelectTest()
        {
            var expected = Create(Model.DirectoryType.提供者);
            Model.RepositoryRegistry.Directory.Add(expected);
            var expected2 = Create(Model.DirectoryType.消费者);
            Model.RepositoryRegistry.Directory.Add(expected2);

            var expected3 = Create(Model.DirectoryType.消费者提供者);
            Model.RepositoryRegistry.Directory.Add(expected3);

            var result = Model.RepositoryRegistry.Directory.Select(Model.DirectoryType.提供者);
            Assert.AreEqual(2, result.Count());
            result = Model.RepositoryRegistry.Directory.Select(Model.DirectoryType.消费者);
            Assert.AreEqual(2, result.Count());

        }
        [Test]
        public void UpdateTest()
        {
            var expected = Create(Model.DirectoryType.提供者);
            Model.RepositoryRegistry.Directory.Add(expected);

            expected.Description = "tst1";
            expected.PingAPIPath = "cc/cc";
            expected.VersionAPIPath = "dd/dd";

            Model.RepositoryRegistry.Directory.Update(expected);

            var result = Model.RepositoryRegistry.Directory.FindBy(expected.Id);
            DirectoryAssert(expected, result);
            
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Directory.RemoveAll();
        }


        void DirectoryAssert(Model.Directory expected, Model.Directory actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PingAPIPath, actual.PingAPIPath);
            Assert.AreEqual(expected.VersionAPIPath, actual.VersionAPIPath);
            Assert.AreEqual(expected.DirectoryType, actual.DirectoryType);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
        }

        public static Model.Directory Create(Model.DirectoryType directoryType = Model.DirectoryType.提供者)
        {
            var directory = new Model.Directory("订单服务")
            {
                Description = "sdfkfjsdlf",
                DirectoryType = directoryType,
                PingAPIPath = "/adfaf/adff",
                VersionAPIPath = "/dfadfadf/adfad",
            };

            return directory;
        }
    }
}

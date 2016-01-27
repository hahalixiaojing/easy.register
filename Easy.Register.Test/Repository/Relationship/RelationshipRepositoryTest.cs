using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Register.Model;
using NUnit.Framework;

namespace Easy.Register.Test.Repository.Relationship
{
    public class RelationshipRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var expected = Create();
            RepositoryRegistry.Relationship.Add(expected);

            Assert.IsTrue(expected.ConsumerInfo.ConsumerDirectoryId > 0&&expected.Provider.ProviderDirectoryId>0);

            var actual = Model.RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.ConsumerDirectoryId);

            Assert.IsTrue(actual.Count() > 0);
        }
        [Test]
        public void AddListTest()
        {
            var expected = Create();
            var expected2 = Create();

            var list = new List<Model.Relationship>() { expected, expected2 };
            Model.RepositoryRegistry.Relationship.Add(list);

            var result = Model.RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.ConsumerDirectoryId);
            Assert.IsTrue(result.Count() == 2);
        }

        [Test]
        public void SelectAllTest()
        {
            var expected = Create();
            RepositoryRegistry.Relationship.Add(expected);

            var expected2 = Create();
            RepositoryRegistry.Relationship.Add(expected2);

            var actual= RepositoryRegistry.Relationship.SelectAll();
            Assert.IsTrue(actual.Count()>0);
        }

        [Test]
        public void RemoveByTest()
        {
            var expected = Create();
            RepositoryRegistry.Relationship.Add(expected);

            RepositoryRegistry.Relationship.Remove(expected.ConsumerInfo.ConsumerDirectoryId);

            var count= RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.ConsumerDirectoryId);
            Assert.IsTrue(count.Count()==0);
        }

        [Test]
        public void SelectTest()
        {
            var expected = Create();
            RepositoryRegistry.Relationship.Add(expected);

            var actual= RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.ConsumerDirectoryId);
            Assert.IsTrue(actual.Count()>0);
        }

        [Test]
        public void RelationIsExistsTest()
        {
            var expected = Create();
            var actual= RepositoryRegistry.Relationship.RelationIsExists(expected.ConsumerInfo.ConsumerDirectoryId,expected.Provider.ProviderDirectoryId);
            Assert.IsTrue(actual);
        }


        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Relationship.RemoveAll();
        }

        public static Model.Relationship Create()
        {
            var relationship = new Model.Relationship(new ConsumerInfo("订单", 1), new ProviderInfo("菜单", 1));
            return relationship;
        }

        private void RelationshipAssert(Model.Relationship expected, Model.Relationship actual)
        {
            Assert.AreEqual(expected.ConsumerInfo.ConsumerDirectoryId, actual.ConsumerInfo.ConsumerDirectoryId);
            Assert.AreEqual(expected.ConsumerInfo.ConsumerName,actual.ConsumerInfo.ConsumerName);
            Assert.AreEqual(expected.Provider.ProviderDirectoryId,actual.Provider.ProviderDirectoryId);
            Assert.AreEqual(expected.Provider.ProviderName, actual.Provider.ProviderName);
        }
    }
}

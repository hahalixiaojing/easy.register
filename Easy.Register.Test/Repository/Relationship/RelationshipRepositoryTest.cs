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

            Assert.IsTrue(expected.ConsumerInfo.DirectoryId > 0&&expected.Provider.DirectoryId>0);

            var actual = Model.RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.DirectoryId);

            Assert.IsTrue(actual.Count() > 0);
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

            RepositoryRegistry.Relationship.Remove(expected.ConsumerInfo.DirectoryId);

            var count= RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.DirectoryId);
            Assert.IsTrue(count.Count()==0);
        }

        [Test]
        public void SelectTest()
        {
            var expected = Create();
            RepositoryRegistry.Relationship.Add(expected);

            var actual= RepositoryRegistry.Relationship.Select(expected.ConsumerInfo.DirectoryId);
            Assert.IsTrue(actual.Count()>0);
        }

        [Test]
        public void RelationIsExistsTest()
        {
            var expected = Create();
            var actual= RepositoryRegistry.Relationship.RelationIsExists(expected.ConsumerInfo.DirectoryId,expected.Provider.DirectoryId);
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
            Assert.AreEqual(expected.ConsumerInfo.DirectoryId, actual.ConsumerInfo.DirectoryId);
            Assert.AreEqual(expected.ConsumerInfo.Name,actual.ConsumerInfo.Name);
            Assert.AreEqual(expected.Provider.DirectoryId,actual.Provider.DirectoryId);
            Assert.AreEqual(expected.Provider.Name,actual.Provider.Name);
        }
    }
}

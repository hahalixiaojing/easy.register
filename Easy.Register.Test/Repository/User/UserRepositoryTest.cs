using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Easy.Register.Test.Repository.User
{
    public class UserRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var usr = Create();
            Model.RepositoryRegistry.User.Add(usr);

            Assert.IsTrue(usr.Id > 0);

            var actual = Model.RepositoryRegistry.User.FindBy(usr.Id);

            UserAssert(usr, actual);
        }
        [Test]
        public void FindAllTest()
        {
            var usr = Create();
            Model.RepositoryRegistry.User.Add(usr);

            var list = Model.RepositoryRegistry.User.FindAll();

            Assert.IsTrue(list.Count > 0);
        }
        [Test]
        public void UpdateTest()
        {
            var usr = Create();
            Model.RepositoryRegistry.User.Add(usr);

            usr.Username = "lixiaojing";
            usr.Name = "李晓静";

            Model.RepositoryRegistry.User.Update(usr);

            var actual = Model.RepositoryRegistry.User.FindBy(usr.Id);

            UserAssert(usr, actual);
        }

        void UserAssert(Model.User.User expected,Model.User.User actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
        }
        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.User.RemoveAll();
        }

        public static Model.User.User Create()
        {
            var user = new Model.User.User()
            {
                Name = "lsdkfdjls",
                Password = "dfdsaf",
                Username = "dsfad"
            };
            return user;
        }
    }
}

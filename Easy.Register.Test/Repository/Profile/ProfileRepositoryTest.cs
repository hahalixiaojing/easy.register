using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Register.Model;
using Easy.Register.Model.Profile;
using NUnit.Framework;

namespace Easy.Register.Test.Repository.Profile
{
    public class ProfileRepositoryTest
    {
        [Test]
        public void Add()
        {
            var profile = new ApplicationProfile("123", "123", ProfileContentType.XML);
            profile.UpdateContent("12123");

            RepositoryRegistry.ApplicationProfile.Add(profile);

            var actual = RepositoryRegistry.ApplicationProfile.FindBy(profile.Id);

            Assert.AreEqual(profile.Id, actual.Id);
            Assert.AreEqual(profile.ApplicationName, actual.ApplicationName);
            Assert.AreEqual(profile.Content, actual.Content);
            Assert.AreEqual(profile.ContentType, actual.ContentType);
            Assert.AreEqual(profile.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(profile.ProfileName, actual.ProfileName);
            Assert.AreEqual(profile.LastUpdate.Hour, actual.LastUpdate.Hour);
        }
        [Test]
        public void UpdateTest()
        {
            var profile = new ApplicationProfile("123", "123", ProfileContentType.XML);
            profile.UpdateContent("12123");

            RepositoryRegistry.ApplicationProfile.Add(profile);

            profile.UpdateContent("9999");
            RepositoryRegistry.ApplicationProfile.Update(profile);

            var actual = RepositoryRegistry.ApplicationProfile.FindBy(profile.Id);
            Assert.AreEqual(profile.Content, actual.Content);
            Assert.AreEqual(profile.LastUpdate.Hour, actual.LastUpdate.Hour);
        }

        [TearDown]
        public void Clear()
        {
            RepositoryRegistry.ApplicationProfile.RemoveAll();
        }
    }
}

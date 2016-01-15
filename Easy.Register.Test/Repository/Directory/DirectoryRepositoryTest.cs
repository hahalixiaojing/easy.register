using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reflection;
using System.IO;
using System.Xml.XPath;
namespace Easy.Register.Test.Repository.Directory
{

    public class DirectoryRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            Assembly ass = Assembly.ReflectionOnlyLoadFrom("Easy.Register.Infrastructure.dll");

            Stream stream = ass.GetManifestResourceStream("Easy.Register.Infrastructure.Repository.repository.xml");


            XPathDocument docu = new XPathDocument(stream);
            var naiv = docu.CreateNavigator();

            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            Assert.IsTrue(expected.Id > 0);

            var actual = Model.RepositoryRegistry.Directory.FindBy(expected.Id);

            DirectoryAssert(expected, actual);
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

        public static Model.Directory Create()
        {
            var directory = new Model.Directory()
            {
                Description = "sdfkfjsdlf",
                DirectoryType = Model.DirectoryType.提供者,
                Name = "订单服务",
                PingAPIPath = "/adfaf/adff",
                VersionAPIPath = "/dfadfadf/adfad",
            };

            return directory;
        }
    }
}

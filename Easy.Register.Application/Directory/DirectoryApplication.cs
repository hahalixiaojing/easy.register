using Easy.Domain.Application;
using Easy.Register.Application.Models;
using Easy.Register.Application.Models.Directory;
using Easy.Register.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Directory
{
    /// <summary>
    /// 目录操作
    /// </summary>
    public class DirectoryApplication : BaseApplication
    {
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="name">目录名称</param>
        /// <param name="description">目录描述</param>
        /// <param name="pingApiPath">pingApi路径</param>
        /// <param name="versionApiPath">版本号Api路径</param>
        /// <param name="directoryType">目录类型</param>
        /// <returns></returns>
        public Return Create(string name, string description, string pingApiPath, string versionApiPath,int directoryType)
        {
            var directory = new Model.Directory(name)
            {
                Description = description,
                PingAPIPath = pingApiPath,
                VersionAPIPath = versionApiPath,
                DirectoryType = (Model.DirectoryType)directoryType
            };

            if (directory.Validate())
            {
                Model.RepositoryRegistry.Directory.Add(directory);
                return new Return();
            }
            return new Return() { Message = directory.GetBrokenRules()[0].Description, Code = directory.GetBrokenRules()[0].Name };
        }
        /// <summary>
        /// 更新目录
        /// </summary>
        /// <param name="directoryId">目录ID</param>
        /// <param name="description">目录描述</param>
        /// <param name="pingApiPath">pingApi路径</param>
        /// <param name="versionApiPath">版本号Api路径</param>
        /// <param name="directoryType">目录类型</param>
        /// <returns></returns>
        public Return Update(int directoryId, string description, string pingApiPath, string versionApiPath, int directoryType)
        {
            Model.Directory directory = Model.RepositoryRegistry.Directory.FindBy(directoryId);
            if (directory == null)
            {
                return new Return() { Code = "d00003", Message = "目录不存在" };
            }

            directory.Description = description;
            directory.PingAPIPath = pingApiPath;
            directory.VersionAPIPath = versionApiPath;
            directory.DirectoryType = (DirectoryType)directoryType;

            if (directory.Validate())
            {
                Model.RepositoryRegistry.Directory.Update(directory);
                return new Return();
            }
            return new Return() { Message = directory.GetBrokenRules()[0].Description, Code = directory.GetBrokenRules()[0].Name };
        }

        /// <summary>
        /// 查询目录列表
        /// </summary>
        /// <param name="directoryType">目录类型</param>
        /// <returns></returns>
        public Return Select(int directoryType)
        {
            IEnumerable<Model.Directory> list = Model.RepositoryRegistry.Directory.Select((Model.DirectoryType)directoryType);

            var listmodel = list.Select(d => new DirectoryModel()
            {
                CreateDate = d.CreateDate,
                Description = d.Description,
                DirectoryType = d.DirectoryType.GetHashCode(),
                Name = d.Name,
                PingAPIPath = d.PingAPIPath,
                VersionAPIPath = d.VersionAPIPath
            });
            return new Return() { DataBody = listmodel };
        }
    }
}

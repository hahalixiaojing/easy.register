using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Profile;

namespace Easy.Register.Application.Profile
{
    public class ProfileApplication : BaseApplication
    {
        public void Create(CreateProfileModel profile)
        {
            var p = new Model.Profile.ApplicationProfile(profile.ApplicationName, profile.ProfileName, (Model.Profile.ProfileContentType)profile.ContentType);

            if (p.Validate())
            {
                Model.RepositoryRegistry.ApplicationProfile.Add(p);
            }
        }
        public void Update(string content,int profileId)
        {
            var p = Model.RepositoryRegistry.ApplicationProfile.FindBy(profileId);
            p.UpdateContent(content);
            if (p.Validate())
            {
                Model.RepositoryRegistry.ApplicationProfile.Update(p);
            }
        }
        public IEnumerable<SelectResponseModel> Select()
        {
            return Model.RepositoryRegistry.ApplicationProfile.Select().Select(m => new SelectResponseModel()
            {
                ApplicationName = m.ApplicationName,
                Content = m.Content,
                ContentType = (int)m.ContentType,
                CreateDate = m.CreateDate,
                LastUpdate = m.LastUpdate,
                ProfileName = m.ProfileName
            });
        }
        public SelectResponseModel FindBy(int id)
        {
            var profile = Model.RepositoryRegistry.ApplicationProfile.FindBy(id);

            if (profile == null)
            {
                return null;
            }

            return new SelectResponseModel()
            {
                ApplicationName = profile.ApplicationName,
                Content = profile.Content,
                ContentType = (int)profile.ContentType,
                CreateDate = profile.CreateDate,
                LastUpdate = profile.LastUpdate,
                ProfileName = profile.ProfileName
            };
        }
    }
}

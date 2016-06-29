using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Profile;

namespace Easy.Register.Application
{
    public class ProfileApplication : BaseApplication
    {
        public void Create(CreateProfileModel profile)
        {
            var p = new Model.Profile.ApplicationProfile(profile.ApplicationName, profile.ProfileName, (Model.Profile.ProfileContentType)profile.ContentType);
            p.UpdateContent(profile.Content);

            if (p.Validate())
            {
                Model.RepositoryRegistry.ApplicationProfile.Add(p);
                this.PublishEvent("Create", new Profile.CreateDomainEvents.CreateDomainEvent(p.Content, p.SubscribeKey));
                return;
            }
            throw new Easy.Domain.Base.BrokenRuleException(p.GetBrokenRules()[0].Name, p.GetBrokenRules()[0].Description);
        }
        public void Update(string content,int profileId)
        {
            var p = Model.RepositoryRegistry.ApplicationProfile.FindBy(profileId);
            p.UpdateContent(content);
            if (p.Validate())
            {
                Model.RepositoryRegistry.ApplicationProfile.Update(p);
                this.PublishEvent("Update", new Profile.UpdateDomainEvents.UpdateDomainEvents(content, p.SubscribeKey));
                return;
            }
            throw new Easy.Domain.Base.BrokenRuleException(p.GetBrokenRules()[0].Name, p.GetBrokenRules()[0].Description);
        }
        public IEnumerable<SelectResponseModel> Select()
        {
            return Model.RepositoryRegistry.ApplicationProfile.Select().Select(m => new SelectResponseModel()
            {
                Id = m.Id,
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
                Id = profile.Id,
                ApplicationName = profile.ApplicationName,
                Content = profile.Content,
                ContentType = (int)profile.ContentType,
                CreateDate = profile.CreateDate,
                LastUpdate = profile.LastUpdate,
                ProfileName = profile.ProfileName
            };
        }

        public string FindProfileContent(string application,string profile)
        {
            string content = Model.RepositoryRegistry.ApplicationProfile.FindProfileContent(application, profile);
            return content;
        }
    }
}

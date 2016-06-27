using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Validators;

namespace Easy.Register.Model.Profile
{
    public class ApplicationProfileValidation:EntityValidation<ApplicationProfile>
    {
        public ApplicationProfileValidation()
        {
            this.IsNullOrWhiteSpace(m => m.Content, ApplicationProfileBrokenRuleMessage.ContentIsError);
        }
    }
}

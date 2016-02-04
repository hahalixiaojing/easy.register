using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Validators;

namespace Easy.Register.Model.User
{
    public class UserValidation : EntityValidation<User>
    {
        public UserValidation()
        {
            this.IsNullOrWhiteSpace(m => m.Username, UserBrokenRuleMessage.UsernameIsError);
            this.IsNullOrWhiteSpace(m => m.Name, UserBrokenRuleMessage.NameIsError);
            this.IsNullOrWhiteSpace(m => m.Password, UserBrokenRuleMessage.PasswordError);
            this.AddRule((s) => {

                return !Model.RepositoryRegistry.User.UsernameIsExists(s.Username, s.Id);

            }, UserBrokenRuleMessage.UsernameExists);
        }
    }
}

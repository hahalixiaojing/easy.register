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
            this.IsNullOrWhiteSpace(m => m.Username, "");
            this.IsNullOrWhiteSpace(m => m.Name, "");
            this.IsNullOrWhiteSpace(m => m.Password, "");
        }
    }
}

using Easy.Domain.Base;
using Easy.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class DirectoryValidation : EntityValidation<Directory>
    {
        public DirectoryValidation()
        {
            this.IsNullOrWhiteSpace(m => m.Name, DirectoryBrokenRuleMessage.NameIsEmpty);
            this.AddRule((d) => {
                return !RepositoryRegistry.Directory.DirectoryIsExists(d);
            
            }, DirectoryBrokenRuleMessage.NameIsExists);
        }
    }
}

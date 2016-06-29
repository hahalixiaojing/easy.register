using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.Profile
{
    public interface IApplicationProfileRepository
    {
        void Add(ApplicationProfile profile);
        ApplicationProfile FindBy(int id);
        void Update(ApplicationProfile profile);
        void RemoveAll();
        IEnumerable<ApplicationProfile> Select();
        string FindProfileContent(string application, string profile);
    }
}

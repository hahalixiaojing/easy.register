using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public.Security.Cryptography;

namespace Easy.Register.Model.User
{
    public class PasswordService
    {
        public string Encrypt(string password)
        {
            return MD5Helper.Encrypt("@#SSSS" + password);
        }
    }
}

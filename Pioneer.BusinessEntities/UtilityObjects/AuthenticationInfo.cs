using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.BusinessEntities.UtilityObjects
{
    public class AuthenticationInfo
    {
        public string Password
        {
            get; set;
        }
        public string AuthToken
        {
            get; set;
        }
        public string TokenExpiry
        {
            get; set;
        }
        public string IssuedOn
        {
            get; set;
        }
        public string ExpiresOn
        {
            get; set;
        }
    }
}
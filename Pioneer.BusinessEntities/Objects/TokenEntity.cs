using System;
using System.Collections.Generic;
using System.Text;

namespace Pioneer.BusinessEntities.Objects
{
    public class TokenEntity
    {
        public int TokenId { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string AuthToken { get; set; }
        public System.DateTime IssuedOn { get; set; }
        public System.DateTime ExpiresOn { get; set; }
    }
}

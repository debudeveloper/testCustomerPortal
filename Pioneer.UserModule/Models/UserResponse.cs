using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.UserModule.Models
{
    public class UserResponse
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string EmailAddress { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public bool? Opt { get; set; }
        public int UserType { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}

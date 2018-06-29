
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.BusinessEntities.UtilityObjects
{
    public abstract class BaseUser : BaseEntity
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Address1 { get; set; } 
        public string City { get; set; }
        public string PostCode { get; set; }   
        public bool? Opt { get; set; }
        public int UserType { get; set; }
    }
}

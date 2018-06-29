using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.UserModule.Models
{
    public class UserCreate
    {
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; } // its present on BasicAuthenticationInfo need to check
        [Required]
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public bool? Opt { get; set; }
        [Required]
        public int UserType { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pioneer.BusinessEntities.Objects
{
    public class CustomerAPI
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        // [DynamoDBRangeKey]
        public string UserType { get; set; } = "Customer";
        // [DynamoDBRangeKey]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        //public EntityStatus DeleteStatus { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string PostcodeOutWard { get; set; } = string.Empty;
        public string PostcodeInWard { get; set; } = string.Empty;
        public string WorkPhone { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        // [DynamoDBHashKey]
        public string EmailAddress { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string MatchType { get; set; } = string.Empty;
        public string Keyword { get; set; } = string.Empty;
        //public Status Status { get; set; } = Status.New;
        public bool Dnc { get; set; }
        public string OrganizationHashCode { get; set; } = string.Empty;
        public bool? Opt { get; set; }
        public string AdditionalInformation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;
        //public ContactTime ContactTime { get; set; } = ContactTime.Anytime;
        // public LeadCategory LeadCategory { get; set; } = LeadCategory.CompleteForm;
        //  public LeadType LeadType { get; set; } = LeadType.Default;
        public bool IsSubscribe { get; set; } = true;
        public string Street { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public bool? IsAppliaedDataProtection { get; set; }
        public bool? IsVerified { get; set; }
        //[DynamoDBGlobalSecondaryIndexHashKey]
        public string Password { get; set; }

      //  [DynamoDBProperty(typeof(AuthenticationInfoConverter))]
        public AuthenticationInfo AuthData
        {
            get; set;
        }
    }


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

    //public class AuthenticationInfoConverter : IPropertyConverter
    //{
    //    public DynamoDBEntry ToEntry(object value)
    //    {
    //        AuthenticationInfo authInfo = value as AuthenticationInfo;
    //        if (authInfo == null) throw new ArgumentOutOfRangeException();

    //        string data = string.Format("{1}{0}{2}{0}{3}{0}{4}", " x ",
    //                        authInfo.Password, authInfo.AuthToken, authInfo.IssuedOn, authInfo.ExpiresOn);

    //        DynamoDBEntry entry = new Primitive
    //        {
    //            Value = data
    //        };
    //        return entry;
    //    }

    //    public object FromEntry(DynamoDBEntry entry)
    //    {
    //        Primitive primitive = entry as Primitive;
    //        if (primitive == null || !(primitive.Value is String) || string.IsNullOrEmpty((string)primitive.Value))
    //            throw new ArgumentOutOfRangeException();

    //        string[] data = ((string)(primitive.Value)).Split(new string[] { " x " }, StringSplitOptions.None);
    //        if (data.Length != 4) throw new ArgumentOutOfRangeException();

    //        AuthenticationInfo complexData = new AuthenticationInfo
    //        {
    //            Password = Convert.ToString(data[0]),
    //            AuthToken = Convert.ToString(data[1]),
    //            IssuedOn = Convert.ToString(data[2]),
    //            ExpiresOn = Convert.ToString(data[3])
    //        };
    //        return complexData;
    //    }
    //}

}

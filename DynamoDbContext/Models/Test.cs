using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamoDbContext.Models
{
    public class Test : ITest
    {
        public string GetName()
        {
            return "Jay Maa Kali";
        }
    }
}
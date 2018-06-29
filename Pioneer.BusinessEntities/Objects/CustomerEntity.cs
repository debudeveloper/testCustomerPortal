using Pioneer.BusinessEntities.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.BusinessEntities.Objects
{
    public class CustomerEntity : BaseUser
    {
        public string Products { get; set; }
    }
}

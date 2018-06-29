using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pioneer.BusinessEntities.UtilityObjects
{
    public enum LeadType
    {
        Default = 1,
        CrossSale,
        [Description("Email Marketing")]
        EmailMarketing,
        Facebook
    }
}


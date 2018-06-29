using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pioneer.BusinessEntities.UtilityObjects
{
    public enum LeadCategory
    {
        [Description("Complete Form")]
        CompleteForm = 1,
        [Description("Short Form")]
        ShortForm,
        [Description("Request Call Form")]
        RequestCallForm,
        [Description("Request Product Form")]
        RequestProductForm
    }
}
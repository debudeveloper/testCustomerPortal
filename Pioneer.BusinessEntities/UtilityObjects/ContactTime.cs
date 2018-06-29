using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pioneer.BusinessEntities.UtilityObjects
{
    public enum ContactTime
    {
        [Description("Morning")]
        Morning = 1,
        [Description("Afternoon")]
        Afternoon,
        [Description("Evening")]
        Evening,
        [Description("Anytime")]
        Anytime
    }
}

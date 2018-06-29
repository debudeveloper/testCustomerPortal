using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pioneer.BusinessEntities.UtilityObjects
{
    public enum Status
    {
        New = 1,
        Test,
        Transferred,
        Park,
        Duplicate,
        Error,
        [Description("Pending Match")]
        PendingMatch,
        [Description("Not Transferred")]
        NotTransfered,
        Partial,
        Hoax,
        Processing,
        [Description("Transfer Delay")]
        TransferDelay
    }
}

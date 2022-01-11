using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionInitArgs
    {
        public XblMultiplayerSessionInitArgs()
        {
        }

        public UInt32 MaxMembersInSession { get; set; }
        public XblMultiplayerSessionVisibility Visibility { get; set; }
        public UInt64[] InitiatorXuids { get; set; }
        public string CustomJson { get; set; }
    }
}
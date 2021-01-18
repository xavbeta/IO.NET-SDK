using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    class IOSimpleMessage : IOMessage
    {
        public IOMessageContent Content { get; set; }
        public int TimeToLive { get; set; } = 3600;
        public IOUser recipient { get; set; } 
    }
}

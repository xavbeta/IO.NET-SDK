using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    
    public interface IOMessage
    {
        
        IOMessageContent Content { get; set; }
        int TimeToLive { get; set; }
    }
}

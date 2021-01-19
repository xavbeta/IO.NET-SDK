using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    public interface IOService
    {
        string ApiKey { get; set; }
        IEnumerable<IOUser> EnabledUsers { get; set; }

        Task<IDictionary<IOUser, bool>> UpdateUsers();

        Task<bool> SendMessage(IOMessage msg, IOUser user);

        Task<IDictionary<IOUser, bool>> SendMessage(IOMessage msg, IEnumerable<IOUser> users); 
    }
}

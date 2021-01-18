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
        DBConnection Connection { get; set; }

        List<IOUser> UpdateUsers(out List<IOUser> disabledUser);

        bool SendMessage(IOMessage msg, IOUser user);

        Dictionary<IOUser, bool> SendMessage(IOMessage msg, List<IOUser> users);
    }
}

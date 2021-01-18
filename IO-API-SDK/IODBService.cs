using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    class IODBService : IOService
    {
        public string ApiKey { get; set; }
        public DBConnection Connection { get; set; }

        internal IODBService()
        {
            this.ApiKey = "";
            this.Connection = new DBConnection();
        }

        IODBService(string ApiKey, DBConnection connection)
        {
            this.ApiKey = ApiKey;
            this.Connection = connection;
        }

        bool IOService.SendMessage(IOMessage msg, IOUser user)
        {
            throw new NotImplementedException();
        }

        public Dictionary<IOUser, bool> SendMessage(IOMessage msg, List<IOUser> users)
        {
            throw new NotImplementedException();
        }
        
        List<IOUser> IOService.UpdateUsers(out List<IOUser> disabledUser)
        {
            throw new NotImplementedException();
        }
    }
}

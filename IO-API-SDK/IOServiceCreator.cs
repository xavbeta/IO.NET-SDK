using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    public class IOServiceCreator
    {
        private static IOServiceCreator instance;

        private IOServiceCreator() => Reset();
        
        public static IOServiceCreator Instance
        {
            get { 
                if(instance == null) {
                    instance = new IOServiceCreator();
                }

                return instance;
            }
        }

        private IOService service;

        private void Reset()
        {
            service = new IOSimpleService();
        }

        public void SetApiKey(string ApiKey)
        {
            service.ApiKey = ApiKey;
        }

        public void SetEnabledUsers(IEnumerable<IOUser> enabledUsers)
        {
            service.EnabledUsers = enabledUsers;
        }

        public IOService GetService()
        {
            var tmp = service;
            Reset();

            return tmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO_API_SDK;

namespace IO_API_SDKTester
{
    class Program
    {

        const string API_KEY = "82b7eead5dcd4bb5b23f7b3fbdccc191";
        const string TEST_USER = "AAAAAA00A00A000A";

        static async Task Main(string[] args)
        {

            // Create the Service instance
            IOServiceCreator srvCreator = IOServiceCreator.Instance;

            srvCreator.SetApiKey(API_KEY);
            srvCreator.SetEnabledUsers(new List<IOUser> { new IOUser { FiscalCode = TEST_USER } });
            
            IOService service = srvCreator.GetService();


            // Create a message
            IOMessageCreator msgCreator = IOMessageCreator.Instance;
            msgCreator.SetSubject("TEST SUBJECT");
            msgCreator.SetBody("## TEST BODY\nLet's hope it works!");
            var msg = msgCreator.GetMessage();
            var disabledUsers = new List<IOUser>();
            
            var enabledUsers = await service.UpdateUsers();


            foreach(var user in enabledUsers)
            {
                if(user.Value)
                    await service.SendMessage(msg, user.Key);
            }

            Console.ReadKey();
        }
    }
}

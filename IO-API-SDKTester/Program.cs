using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO_API_SDK;

namespace IO_API_SDKTester
{
    class Program
    {

        const string API_KEY = "6a71e152c9d5406baf4d2a3da138d7f6";
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
            msgCreator.SetBody("## TEST BODY\nLet's hope it works!\n## TEST BODY\nLet's hope it works!\n## TEST BODY\nLet's hope it works!");
            msgCreator.SetDueDate(DateTime.Today + new TimeSpan(1,0,0,0));
            var msg = msgCreator.GetMessage();
            
            var enabledUsers = await service.UpdateUsers();


            foreach(var user in enabledUsers)
            {
                if (user.Value)
                {
                    var result = await service.SendMessage(msg, user.Key);
                    Debug.Assert(result, "Message sending failure!");
                }
                    
            }

            Console.WriteLine("All done!");

            Console.ReadKey();
        }
    }
}

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

        const string API_KEY = "AAAAAA00A00A000A";

        static void Main(string[] args)
        {

            // Create the Service instance
            IOServiceCreator srvCreator = IOServiceCreator.Instance;

            srvCreator.SetApiKey(API_KEY);
            srvCreator.SetDBConnection(new DBConnection());
            
            IOService service = srvCreator.GetService();


            // Create a message
            IOMessageCreator msgCreator = IOMessageCreator.Instance;
            msgCreator.SetSubject("TEST SUBJECT");
            msgCreator.SetBody("## TEST BODY\nLet's hope it works!");
            var msg = msgCreator.GetMessage();

            List<IOUser> enabledUsers = service.UpdateUsers(out List<IOUser> disabledUser);

            foreach(var user in enabledUsers)
            {
                service.SendMessage(msg, user);
            }

        }
    }
}

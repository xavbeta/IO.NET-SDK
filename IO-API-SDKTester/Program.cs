using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IO_API_SDK;
using IO_API_SDK.Messages;

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
            srvCreator.SetEnabledUsers(new List<IOUser> { new IOUser { FiscalCode = TEST_USER }, new IOUser { FiscalCode = TEST_USER } });
            
            IOService service = srvCreator.GetService();


            // Create a message
            IOMessageCreator msgCreator = IOMessageCreator.Instance;
            msgCreator.SetSubject("TEST SUBJECT");
            msgCreator.SetBody("## TEST BODY\nLet's hope it works!\n## TEST BODY\nLet's hope it works!\n## TEST BODY\nLet's hope it works!");
            //msgCreator.SetBody("## TEST BODY\nLet's hope it works!"); //Too short! 
            msgCreator.SetDueDate(DateTime.Today + new TimeSpan(1,0,0,0)); //tomorrow
            var msg = msgCreator.GetMessage();
            

            // Send messages
            var enabledUsers = await service.UpdateUsers();

            // One by One
            foreach (var user in enabledUsers)
            {
                try
                {
                    if (user.Value)
                    {
                        var result = await service.SendMessage(msg, user.Key);
                        Debug.Assert(!string.IsNullOrEmpty(result), "Message sending failure!");
                    }
                }catch(HttpRequestException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.Data);
                    Debug.WriteLine(ex.InnerException);
                }
                catch(IOMessageFormatException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.Data);
                }    
            }

            /*
            // Or as a single batch 
            try
            {
                var results =  service.SendMessage(msg, enabledUsers.Where(a => a.Value).Select(a => a.Key));
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.Data);
                Debug.WriteLine(ex.InnerException);
            }
            catch (IOMessageFormatException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.Data);
            }
            */

            Console.WriteLine("All done!");

            Console.ReadKey();
        }
    }
}

using IO_API_SDK.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    class IOSimpleService : IOService
    {
        public string ApiKey { get; set; }
        public IEnumerable<IOUser> EnabledUsers { get; set; }

        private Postman postman;

        internal IOSimpleService():this("", new List<IOUser>())
        {}

        IOSimpleService(string ApiKey, IEnumerable<IOUser> enabledUsers)
        {
            this.ApiKey = ApiKey;
            this.EnabledUsers = enabledUsers;
            postman = Postman.GetInstance(ApiKey);
        }


        async Task<IDictionary<IOUser, bool>> IOService.UpdateUsers()
        {
            IDictionary<IOUser, bool> enabled = EnabledUsers.ToDictionary(k=> k, x=> true);

            return await Task.FromResult(enabled);
        }

        async Task<bool> IOService.SendMessage(IOMessage msg, IOUser user)
        {

            postman = Postman.GetInstance(ApiKey);

            if (await postman.CheckUserEnabledAsync(user)) {
                await postman.SendMessage(msg, user);
            }
            return await Task.FromResult(true);
        }

        async Task<IDictionary<IOUser, bool>> IOService.SendMessage(IOMessage msg, IEnumerable<IOUser> users)
        {
            throw new NotImplementedException();
        }
    }
}

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
        public string key;
        public string ApiKey
        {
            get => key; 
            set
            {
                postman = Postman.GetInstance(value);
                key = value;
            } 
        }
        public IEnumerable<IOUser> EnabledUsers { get; set; }

        private Postman postman;

        internal IOSimpleService() :this("", new List<IOUser>())
        {}

        IOSimpleService(string ApiKey, IEnumerable<IOUser> enabledUsers)
        {
            this.ApiKey = ApiKey;
            this.EnabledUsers = enabledUsers;
        }


        public async Task<IDictionary<IOUser, bool>> UpdateUsers()
        {
            postman = Postman.GetInstance(ApiKey);

            var check = await Task.WhenAll(EnabledUsers.Select(async u => await this.postman.CheckUserEnabledAsync(u)));
            return EnabledUsers.Zip(check, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        }

        public async Task<string> SendMessage(IOMessage msg, IOUser user)
        {
            postman = Postman.GetInstance(ApiKey);

            if (await postman.CheckUserEnabledAsync(user)) {
                return await postman.SendMessage(msg, user);
            }
            return await Task.FromResult<string>(null);
        }

        public async Task<IDictionary<IOUser, string>> SendMessage(IOMessage msg, IEnumerable<IOUser> users)
        {
            var results = await Task.WhenAll(users.Select(async u => await this.SendMessage(msg, u)));
            return users.Zip(results, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        }
    }
}

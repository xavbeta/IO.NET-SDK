using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;

namespace IO_API_SDK.Messages
{
    class Postman
    {
        public const string BASE_URI = "https://api.io.italia.it/api/v1/";
        private HttpClient client;

        private static Postman instance;
        private Postman() { }

        public static Postman GetInstance(string key) { 
            
            if(instance == null)
            {
                instance = new Postman();    
            }

            instance.Setup(key);
            return instance;
        }
       

        public void Setup(string key)
        {
           client = new HttpClient();
           client.BaseAddress = new Uri(BASE_URI);
           client.DefaultRequestHeaders.Add("User-Agent", ".NET IO API Client");
           client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CheckUserEnabledAsync(IOUser user)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "profiles");

            
            req.Content = new StringContent(
                    JsonConvert.SerializeObject( new { fiscal_code = user.FiscalCode } ),
                    Encoding.UTF8, 
                    "application/json");

            try
            {
                HttpResponseMessage response = await client.SendAsync(req);
                response.EnsureSuccessStatusCode();

                var resp = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(resp);
                return result.sender_allowed == true;
            } catch(HttpRequestException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            
        }

        public async Task<bool> SendMessage(IOMessage msg, IOUser user)
        {
            if (!msg.Check())
                throw new IOMessageFormatException("One or more fields have wrong format");

            var txt = JsonConvert.SerializeObject(msg);
            Debug.WriteLine(txt);

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"messages/{user.FiscalCode}");

            req.Content = new StringContent(
                    txt,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response = await client.SendAsync(req);
            response.EnsureSuccessStatusCode();

            var resp = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(resp);
            return result.sender_allowed == true;
        }

        /*
        using var client = new HttpClient();

        client.BaseAddress = new Uri("https://api.github.com");
        client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
        client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        var url = "repos/symfony/symfony/contributors";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var resp = await response.Content.ReadAsStringAsync();

        List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(resp);
        contributors.ForEach(Console.WriteLine);

        record Contributor(string Login, short Contributions);
        */
    }
}

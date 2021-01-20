using IO_API_SDK.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    class IOSimpleMessage : IOMessage
    {
        public IOMessageContent Content { get; set; }
        public int TimeToLive { get; set; } = 3600;

        public bool Check()
        {
            return new IOSimpleMessageChecker().CheckMessage(this);
        }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class IOMessageContent
    {
        public string Subject { get; set; }

        public string Markdown { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(CustomIsoDateTimeFormatConverter), "yyyy'-'MM'-'dd'T'HH':'mm':'ss")]
        public DateTime? DueDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PrescriptionData PrescriptionData { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PaymentData PaymentData { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PrescriptionData
    {
        [JsonProperty("nre")]
        public string NRE { get; set; }

        [JsonProperty("iup")]
        public string IUP { get; set; }

        public string PrescriberFiscalCode { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PaymentData
    {
        public float Amount { get; set; }

        public string NoticeNumber { get; set; }

        public DateTime InvalidAfterDueDate { get; set; }
    }
}

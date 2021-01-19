using Newtonsoft.Json;
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
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class IOMessageContent
    {
        public string Subject { get; set; }

        public string Markdown { get; set; }

        public DateTime? DueDate { get; set; }

        public PrescriptionData PrescriptionData { get; set; }

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

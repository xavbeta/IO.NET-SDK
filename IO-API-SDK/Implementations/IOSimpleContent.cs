using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    class IOSimpleContent : IOMessageContent
    {
        public string Subject { get; set; }
        public string Markdown { get; set; }
        public DateTime? DueDate { get; set; }
        public PrescriptionData PrescriptionData { get; set; }
        public PaymentData PaymentData { get; set; }
    }
}

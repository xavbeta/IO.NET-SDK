using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    public interface IOMessageContent
    {
        string Subject { get; set; }

        string Markdown { get; set; }

        DateTime? DueDate { get; set; }

        PrescriptionData PrescriptionData { get; set; }

        PaymentData PaymentData { get; set; }
    }

    public interface PrescriptionData
    {
        string NRE { get; set; }
        string IUP { get; set; }

        string PrescriberFiscalCode { get; set; }
    }

    public interface PaymentData
    {
        float Amount { get; set; }

        string NoticeNumber { get; set; }

        DateTime InvalidAfterDueDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    public class IOMessageCreator
    {
        private static IOMessageCreator instance;

        private IOMessageCreator() => Reset();
        
        public static IOMessageCreator Instance
        {
            get { 
                if(instance == null) {
                    instance = new IOMessageCreator();
                }

                return instance;
            }
        }

        private IOMessage msg;

        private void Reset()
        {
            msg = new IOSimpleMessage() { Content = new IOSimpleContent() };
        }

        public void SetSubject(string subject)
        {
            msg.Content.Subject = subject;
        }

        public void SetBody(string body)
        {
            msg.Content.Markdown = body;
        }

        public void SetDueDate(DateTime dueDate)
        {
            msg.Content.DueDate = dueDate;
        }

        //TODO: explode builder item with lazy instance creation
        public void SetPaymentData(PaymentData paymentData) 
        {
            msg.Content.PaymentData = paymentData;
        }

        //TODO: explode builder item with lazy instance creation
        public void SetPrescriptionData(PrescriptionData prescriptionData)
        {
            msg.Content.PrescriptionData = prescriptionData;
        }

        public IOMessage GetMessage()
        {
            var tmp = msg;
            Reset();

            return tmp;
        }
    }
}

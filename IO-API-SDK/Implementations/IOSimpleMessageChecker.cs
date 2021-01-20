using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    class IOSimpleMessageChecker : IOMessageChecker
    {
        bool CheckMarkdown(string field)
        {
            return !string.IsNullOrEmpty(field)
                && field.Length >= 80
                && field.Length < 10001;
        }

        bool CheckSubject(string
            field)
        {
            return !string.IsNullOrEmpty(field);
        }

        public bool CheckMessage(IOMessage msg)
        {
            return msg != null 
                && msg.Content != null
                && CheckSubject(msg.Content.Subject)
                && CheckMarkdown(msg.Content.Markdown);
        }
    }

    static class IOSimpleMessageExtensions
    {
        static IOMessageChecker GetChecker(this IOSimpleMessage msg)
        {
            return new IOSimpleMessageChecker();
        }
    }
}

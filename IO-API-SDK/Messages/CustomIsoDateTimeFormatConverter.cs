using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK.Messages
{
    public class CustomIsoDateTimeFormatConverter : IsoDateTimeConverter
    {
        public CustomIsoDateTimeFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}

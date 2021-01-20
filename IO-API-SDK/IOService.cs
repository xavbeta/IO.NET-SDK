﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_API_SDK
{
    public interface IOService
    {
        string ApiKey { get; set; }
        IEnumerable<IOUser> EnabledUsers { get; set; }

        /// <summary>Check whether EnabledUsers are still enabled or not.</summary>
        /// <returns>A Dictionary where each IOUser is associated with a boolean indicating whether he/she is currently enabled to receiving messagefrom this service.</returns>
        /// <exception cref="HttpRequestException">This exception is thrown if the HTTPRequest fails.</exception>
        Task<IDictionary<IOUser, bool>> UpdateUsers();

        /// <summary>Send a message to a single user.</summary>
        /// <param name="msg">An non-empty istance of an IOMessage (can be istantiated through IOMessageCreator).</param>
        /// <param name="user">An istance of an IOUser. FiscalCode has to be present.</param>
        /// <returns>A string containing the Message Id generated by the IO api server as acknowledgement or null in case of failure.</returns>
        /// <exception cref="HttpRequestException">This exception is thrown if the HTTPRequest fails.</exception>
        /// <exception cref="IOMEssageFormatException">This exception is thrown if message's fields have wrong format.</exception>
        Task<string> SendMessage(IOMessage msg, IOUser user);

        /// <summary>Just like SendMessage but it enables to send the same message to multiple users at once.</summary>
        /// <param name="msg">An non-empty istance of an IOMessage (can be istantiated through IOMessageCreator).</param>
        /// <param name="user">An Enumeration of IOUser. FiscalCode has to be present for each IOUser.</param>
        /// <returns>A dictionary that associates a IOUser with the Message Id generated by the IO api server as acknowledgement or null in case of failure.</returns>
        /// <exception cref="HttpRequestException">This exception is thrown if the HTTPRequest fails.</exception>
        /// <exception cref="IOMEssageFormatException">This exception is thrown if message's fields have wrong format.</exception>
        Task<IDictionary<IOUser, string>> SendMessage(IOMessage msg, IEnumerable<IOUser> users); 
    }
}

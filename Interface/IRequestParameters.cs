using AppStoreScarpper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Interface
{
   public interface IRequestParameters
    {
        WebHeaderCollection Headers { get; set; }

        // To assign the Cookies for request
        CookieCollection Cookies { get; set; }

        // To specify the media type of the body of the http request
        string ContentType { get; set; }

        // To specify the user agent
        string UserAgent { get; set; }

        // To assign proxy for the http request
        Proxy Proxy { get; set; }

        // If its true, allows the same tcp connection for upcoming http connections
        bool KeepAlive { get; set; }

        // To specify media types which are acceptable for the response
        string Accept { get; set; }

        //To specify the address of the previous pages of the http request
        string Referer { get; set; }

        // To specify the get or post request url
        string Url { get; set; }

        // To specify the post data in bytes of sequences
        byte[] PostData { get; set; }

        //To specify whether request for media type or not, such as images
        bool IsMultiPart { get; set; }

        // To add the header with web header collections
        void AddHeader(string key, string value);
    }
}

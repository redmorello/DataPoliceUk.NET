using System;
using Newtonsoft.Json.Linq;

namespace DataPoliceUk.ErrorHandling
{
    public class ApiRequestException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";
        
        public ApiRequestException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public ApiRequestException(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public ApiRequestException(int statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

        public ApiRequestException(int statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }
    }
}

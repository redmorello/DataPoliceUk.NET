using System;
using System.Collections.Generic;
using System.Net.Http;
using DataPoliceUk.Models;

namespace DataPoliceUk
{
    public class ApiRequestException : ApiException
    {
        public HttpResponseMessage Response { get; set; }

        public ApiRequestException(HttpResponseMessage response, IEnumerable<ApiError> errors, string message = default(string), Exception innerEx = null)
            : base(message ?? $"API Request exception - Http Status Code: {response.StatusCode} - see errors for more details.", errors, innerEx)
        {
            this.Response = response;
        }
    }
}

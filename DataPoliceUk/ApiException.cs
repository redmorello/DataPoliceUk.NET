using System;
using System.Collections.Generic;
using DataPoliceUk.Models;

namespace DataPoliceUk
{
    public class ApiException : Exception
    {
        public List<ApiError> ApiErrors { get; set; }

        public ApiException(string message, IEnumerable<ApiError> errors, Exception innerEx = null) : base(message, innerEx)
        {
            ApiErrors = errors != null ? new List<ApiError>(errors) : new List<ApiError>();
        }
    }
}

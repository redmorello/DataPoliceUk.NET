using System.Collections.Generic;

namespace DataPoliceUk
{
    internal class ClientHelperExtensions
    {
        /// <summary>
        /// Converts the REST api resource into the fully qualified url
        /// </summary>
        /// <param name="apiCall"></param>
        /// <param name="encodedUserId"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static string ToFullUrl(string baseApiUrl, string apiCall, string encodedUserId = default(string), params object[] args)
        {
            string userSignifier = "-"; //used for current user
            if (!string.IsNullOrWhiteSpace(encodedUserId))
            {
                userSignifier = encodedUserId;
            }

            var parameters = new List<object> { userSignifier };
            if (args != null)
            {
                parameters.AddRange(args);
            }

            apiCall = string.Format(apiCall, parameters.ToArray());

            if (apiCall.StartsWith("/"))
            {
                apiCall = apiCall.TrimStart(new[] { '/' });
            }
            return baseApiUrl + apiCall;
        }
    }
}

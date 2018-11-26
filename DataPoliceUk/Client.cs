using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using DataPoliceUk.Models;
using Newtonsoft.Json;

namespace DataPoliceUk
{
    public class Client : IClient
    {
        private const string ApiUrl = "https://data.police.uk/api/";
        private static readonly HttpClient HttpClient = new HttpClient();

        public Client()
        {

        }

        /// <summary>
        /// This API lets you get all Forces.
        /// </summary>
        /// <returns>List of <see cref="Force"/></returns>
        public async Task<List<Force>> GetForces()
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, "/forces");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var forces = JsonConvert.DeserializeObject<List<Force>>(responseBody);
            // TODO do something to check result codes...
            return forces;
        }
        
        /// <summary>
        /// Pass a freeform url. Good for debuging pursposes to get the pure json response back.
        /// </summary>
        /// <param name="apiPath">Fully qualified path including the Fitbit domain.</param>
        /// <returns></returns>
        public async Task<string> GetApiFreeResponseAsync(string apiPath)
        {
            string apiCall = apiPath;

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// General error checking of the response before specific processing is done.
        /// </summary>
        /// <param name="response"></param>
        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                // assumption is error response from fitbit in the 4xx range  
                var errors = new JsonDotNetSerializer().ParseErrors(await response.Content.ReadAsStringAsync());

                //// rate limit hit
                //if (429 == (int)response.StatusCode)
                //{
                //    // not sure if we can use 'RetryConditionHeaderValue' directly as documentation is minimal for the header
                //    var retryAfterHeader = response.Headers.GetValues("Retry-After").FirstOrDefault();
                //    if (retryAfterHeader != null)
                //    {
                //        int retryAfter;
                //        if (int.TryParse(retryAfterHeader, out retryAfter))
                //        {
                //            throw new ApiRateLimitException(retryAfter, errors);
                //        }
                //    }
                //}

                // request exception parsing
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.NotFound:
                        throw new ApiRequestException(response, errors);
                }

                // if we've got here then something unexpected has occured
                throw new ApiException($"An error has occured. Please see error list for details - {response.StatusCode}", errors);
            }
        }
    }
}

using DataPoliceUk.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DataPoliceUk.ErrorHandling;
using DataPoliceUk.JsonConvertors;

namespace DataPoliceUk
{
    public class Client : IClient
    {
        private const string ApiUrl = "https://data.police.uk/api/";
        private static readonly HttpClient HttpClient = new HttpClient();

        public Client()
        {

        }

        public async Task<List<Availability>> GetAvailability()
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, "/crimes-street-dates");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Availability>>(responseBody);
            return result;
        }

        #region Force related

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
            var result = JsonConvert.DeserializeObject<List<Force>>(responseBody);
            return result;
        }

        public async Task<SpecificForce> GetForce(string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/forces/{id}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SpecificForce>(responseBody);
            return result;
        }

        public async Task<List<Person>> GetForcePeople(string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/forces/{id}/people");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Person>>(responseBody);
            return result;
        }

        #endregion

        #region Crime related

        public async Task<List<Crime>> GetStreetCrimeByLocation(string id, string lat, string lng, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/crimes-street/{id}?lat={lat}&lng={lng}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Crime>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<Crime>> GetStreetCrimeByPolyArea(string id, string poly, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/crimes-street/{id}?poly={poly}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Crime>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<CrimeAtLocation>> GetCrimesAtSpecificLocation(string date, string locationId)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/crimes-at-location?date={date}&location_id={locationId}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CrimeAtLocation>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<CrimeAtLocation>> GetCrimesAtLocation(string date, string lat, string lng)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/crimes-at-location?date={date}&lat={lat}&lng={lng}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CrimeAtLocation>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<CrimesNoLocation>> GetCrimesNoLocation(string category, string force, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/crimes-no-location?category={category}&force={force}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CrimesNoLocation>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<Category>> GetCrimeCategories(string date)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/crime-categories?date={date}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Category>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<CrimeLastUpdated> GetCrimeLastUpdated()
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, "/crime-last-updated");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CrimeLastUpdated>(responseBody);
            return result;
        }

        public async Task<List<OutcomeAtLocation>> GetOutcomesAtSpecificLocation(string locationId, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/outcomes-at-location?location_id={locationId}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<OutcomeAtLocation>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<OutcomeAtLocation>> GetOutcomesAtLocation(string lat, string lng, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/outcomes-at-location?lat={lat}&lng={lng}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<OutcomeAtLocation>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<List<OutcomeAtLocation>> GetOutcomesAtCustomLocation(string poly, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/outcomes-at-location?poly={poly}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<OutcomeAtLocation>>(responseBody, Converter.Settings);
            return result;
        }

        public async Task<OutcomesForCrime> GetOutcomesForCrime(string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/outcomes-for-crime/{id}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<OutcomesForCrime>(responseBody, Converter.Settings);
            return result;
        }

        #endregion

        #region Neighbourhood related

        public async Task<List<Neighbourhood>> GetNeighbourhoods(string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/{id}/neighbourhoods");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Neighbourhood>>(responseBody);
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }

        public async Task<SpecificNeighbourhood> GetNeighbourhood(string forceId, string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/{forceId}/{id}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SpecificNeighbourhood>(responseBody);
            return result;
        }

        public async Task<List<BoundaryLocation>> GetNeighbourhoodBoundary(string forceId, string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/{forceId}/{id}/boundary");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BoundaryLocation>>(responseBody);
            return result;
        }

        public async Task<List<Person>> GetNeighbourhoodPeople(string forceId, string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/{forceId}/{id}/people");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Person>>(responseBody);
            return result;
        }

        public async Task<List<Event>> GetNeighbourhoodEvents(string forceId, string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/{forceId}/{id}/events");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Event>>(responseBody);
            return result;
        }

        public async Task<List<Priority>> GetNeighbourhoodPriorities(string forceId, string id)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/{forceId}/{id}/priorities");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Priority>>(responseBody);
            return result;
        }

        public async Task<NeighbourhoodResult> GetNeighbourhoodByLocation(string lat, string lng)
        {
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/locate-neighbourhood?q={lat},{lng}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NeighbourhoodResult>(responseBody);
            return result;
        }

        #endregion

        #region Stop and Search related

        public async Task<List<StopAndSearch>> GetStopAndSearchByArea(string lat, string lng, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/stops-street?lat={lat}&lng={lng}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<StopAndSearch>>(responseBody);
            return result;
        }

        public async Task<List<StopAndSearch>> GetStopAndSearchByPolyArea(string poly, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/stops-street?poly={poly}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<StopAndSearch>>(responseBody);
            return result;
        }

        public async Task<List<StopAndSearch>> GetStopAndSearchByLocation(string locationId, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/stops-at-location?location_id={locationId}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<StopAndSearch>>(responseBody);
            return result;
        }

        public async Task<List<StopAndSearch>> GetStopAndSearchNoLocation(string forceId, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/stops-no-location?force={forceId}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<StopAndSearch>>(responseBody);
            return result;
        }

        public async Task<List<StopAndSearch>> GetStopAndSearchByForce(string forceId, string date = null)
        {
            var dateParameter = !string.IsNullOrEmpty(date) ? $"&date={date}" : string.Empty;
            var apiCall = ClientHelperExtensions.ToFullUrl(ApiUrl, $"/stops-force?force={forceId}{dateParameter}");

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<StopAndSearch>>(responseBody);
            return result;
        }

        #endregion

        #region Debug related

        /// <summary>
        /// Pass a freeform url. Good for debuging pursposes to get the pure json response back.
        /// </summary>
        /// <param name="apiPath">Fully qualified path including the Fitbit domain.</param>
        /// <returns></returns>
        public async Task<string> GetApiFreeResponseAsync(string apiUrl)
        {
            string apiCall = apiUrl;

            HttpResponseMessage response = await HttpClient.GetAsync(apiCall);
            await HandleResponse(response);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// General error checking of the response before specific processing is done.
        /// </summary>
        /// <param name="response"></param>
        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
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
                        throw new ApiRequestException((int)response.StatusCode, $"API Request exception - Http Status Code: {response.StatusCode} - see errors for more details.");
                }

                // if we've got here then something unexpected has occured
                throw new ApiRequestException((int)response.StatusCode, $"An error has occured. Please see error list for details - {response.StatusCode}");
            }
        }

        #endregion
    }
}

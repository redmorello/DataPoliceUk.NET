using System.Collections.Generic;
using System.Threading.Tasks;
using DataPoliceUk.Models;

namespace DataPoliceUk
{
    public interface IClient
    {
        Task<List<Availability>> GetAvailability();

        #region Force related

        Task<List<Force>> GetForces();
        Task<SpecificForce> GetForce(string id);
        Task<List<Person>> GetForcePeople(string id);

        #endregion

        #region Crime related

        Task<List<Crime>> GetStreetCrimeByLocation(string id, string lat, string lng, string date = null);
        Task<List<Crime>> GetStreetCrimeByPolyArea(string id, string poly, string date = null);
        Task<List<CrimeAtLocation>> GetCrimesAtSpecificLocation(string date, string locationId);
        Task<List<CrimeAtLocation>> GetCrimesAtLocation(string date, string lat, string lng);
        Task<List<CrimesNoLocation>> GetCrimesNoLocation(string category, string force, string date = null);
        Task<List<Category>> GetCrimeCategories(string date);
        Task<CrimeLastUpdated> GetCrimeLastUpdated();
        Task<List<OutcomeAtLocation>> GetOutcomesAtSpecificLocation(string locationId, string date = null);
        Task<List<OutcomeAtLocation>> GetOutcomesAtLocation(string lat, string lng, string date = null);
        Task<List<OutcomeAtLocation>> GetOutcomesAtCustomLocation(string poly, string date = null);
        Task<OutcomesForCrime> GetOutcomesForCrime(string id);

        #endregion

        #region Neighbourhood related

        Task<List<Neighbourhood>> GetNeighbourhoods(string id);
        Task<SpecificNeighbourhood> GetNeighbourhood(string forceId, string id);
        Task<List<BoundaryLocation>> GetNeighbourhoodBoundary(string forceId, string id);
        Task<List<Person>> GetNeighbourhoodPeople(string forceId, string id);
        Task<List<Event>> GetNeighbourhoodEvents(string forceId, string id);
        Task<List<Priority>> GetNeighbourhoodPriorities(string forceId, string id);
        Task<NeighbourhoodResult> GetNeighbourhoodByLocation(string lat, string lng);

        #endregion

        #region Stop and Search related

        Task<List<StopAndSearch>> GetStopAndSearchByArea(string lat, string lng, string date = null);
        Task<List<StopAndSearch>> GetStopAndSearchByPolyArea(string poly, string date = null);
        Task<List<StopAndSearch>> GetStopAndSearchByLocation(string locationId, string date = null);
        Task<List<StopAndSearch>> GetStopAndSearchNoLocation(string forceId, string date = null);
        Task<List<StopAndSearch>> GetStopAndSearchByForce(string forceId, string date = null);

        #endregion

        #region Debug related

        Task<string> GetApiFreeResponseAsync(string apiUrl);

        #endregion
    }
}

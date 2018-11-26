using System.Collections.Generic;
using System.Threading.Tasks;
using DataPoliceUk.Models;

namespace DataPoliceUk
{
    public interface IClient
    {
        Task<List<Force>> GetForces();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docker.Core.Entities;

namespace Docker.Core.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCity();
        Task<City> GetCities(int id);
        Task InsertCity(City city);
        Task<bool> UpdateCity(City city);
        Task<bool> DeleteCity(int id);
    }
}

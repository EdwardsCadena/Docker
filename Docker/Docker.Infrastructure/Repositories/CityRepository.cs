using Microsoft.EntityFrameworkCore;
using Docker.Core.Entities;
using Docker.Core.Interfaces;
using Docker.Infrastructure.Data;

namespace Docker.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DockerContext _context;

        public CityRepository(DockerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCity()
        {
            var city = await _context.Cities.ToListAsync();
            return city;
        }
        public async Task<City> GetCities(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.CodeCity == id);
            return city;

        }
        public async Task InsertCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateCity(City city)
        {
            var result = await GetCities(city.CodeCity);
            result.Description = city.Description;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteCity(int id)
        {
            var delete = await GetCities(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}

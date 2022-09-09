using AutoMapper;
using Docker.Core.DTOs;
using Docker.Core.Entities;
using Docker.Core.Interfaces;
using Docker.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Docker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _maper;
        public CityController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _maper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeller()
        {
            var city = await _cityRepository.GetCity();
            var citydto = _maper.Map<IEnumerable<CityDTOs>>(city);
            return Ok(citydto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitiess(int id)
        {
            var cityget = await _cityRepository.GetCities(id);
            var citysget = _maper.Map<CityDTOs>(cityget);
            return Ok(citysget);
        }
        [HttpPost]
        public async Task<IActionResult> PostSeller(CityDTOs CityDTOs)
        {
            var citypost = _maper.Map<City>(CityDTOs);
            await _cityRepository.InsertCity(citypost);
            return Ok(CityDTOs);
        }
        [HttpPut]
        public async Task<IActionResult> PutSeller(int id, CityDTOs City)
        {
            var CityPut = _maper.Map<City>(City);
            CityPut.CodeCity = id;
            var Update = await _cityRepository.UpdateCity(CityPut);
            var updatecity = new ApiResponse<bool>(Update);
            return Ok(updatecity);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {

            var result = await _cityRepository.DeleteCity(id);
            var deletecity = new ApiResponse<bool>(result);
            return Ok(deletecity);
        }
    }
}

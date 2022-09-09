using AutoMapper;
using Docker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Docker.Response;
using Docker.Core.Interfaces;
using Docker.Core.DTOs;
using Docker.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Docker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _maper;
        public SellerController(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _maper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeller()
        {
            var alquiler = await _sellerRepository.GetSeller();
            var alquilerdto = _maper.Map<IEnumerable<SellerDTOs>>(alquiler);
            return Ok(alquilerdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSellers(int id)
        {
            var Sellerget = await _sellerRepository.GetSellers(id);
            var Sellersget = _maper.Map<SellerDTOs>(Sellerget);
            return Ok(Sellersget);
        }
        [HttpPost]
        public async Task<IActionResult> PostSeller(SellerDTOs SellerDtos)
        {
            var sellerpost = _maper.Map<Seller>(SellerDtos);
            await _sellerRepository.InsertSeller(sellerpost);
            return Ok(SellerDtos);
        }
        [HttpPut]
        public async Task<IActionResult> PutSeller(int id, SellerDTOs seller)
        {
            var SellerPut = _maper.Map<Seller>(seller);
            SellerPut.CodeSeller = id;
            var Update = await _sellerRepository.UpdateSeller(SellerPut);
            var updateSeller = new ApiResponse<bool>(Update);
            return Ok(updateSeller);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {

            var result = await _sellerRepository.DeleteSeller(id);
            var deleteseller = new ApiResponse<bool>(result);
            return Ok(deleteseller);
        }
    }
}

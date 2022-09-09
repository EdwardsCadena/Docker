using Docker.Core.DTOs;
using Docker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;


namespace Docker.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            
            CreateMap<Seller, SellerDTOs>();
            CreateMap<SellerDTOs, Seller>();

            CreateMap<City, CityDTOs>();
            CreateMap<CityDTOs, City>();

        }
         
            
    }
}

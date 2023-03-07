﻿using AutoMapper;
using MVilla_Web.Models.Dto;

namespace MVilla_Web
{
    public class MappingConfig : Profile
    {
       public MappingConfig() 
        {
           
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
        }

    }
}

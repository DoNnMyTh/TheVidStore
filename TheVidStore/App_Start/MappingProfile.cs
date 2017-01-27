using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TheVidStore.Dtos;
using TheVidStore.Models;

namespace TheVidStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //Dto To Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}
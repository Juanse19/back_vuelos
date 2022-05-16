using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuelosAPI.DTOs;
using VuelosAPI.Entidades;

namespace VuelosAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Airline, AirlineDTO>().ReverseMap();
            CreateMap<AirlineCreacionDTO, Airline>();
            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<FlightCreacionDTO, Flight>();
        }
    }
}

using AutoMapper;
using Business.Dtos.Fuel;
using Business.Requests.FuelRequest;
using Business.Requests.TransmissionRequest;
using Business.Responses.FuelResponse;
using Business.Responses.TransmissionResponse;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class FuelMapperProfiles: Profile
    {
        public FuelMapperProfiles()
        {
            CreateMap<AddFuelRequest,Fuel>();
            CreateMap<Fuel, AddFuelResponse>();
            CreateMap<GetByIdFuelRequest , Fuel>();
            CreateMap<Fuel, GetByIdFuelResponse>();
            CreateMap<UpdateFuelRequest, Fuel>();
            CreateMap<Transmission, UpdateFuelResponse>();
            CreateMap<DeleteFuelRequest, Fuel>();
            CreateMap<Transmission, DeleteFuelResponse>();
            CreateMap<GetListFuelRequest, Transmission>();
            CreateMap<Fuel, FuelListItemDto>();
            
        }
    }
}

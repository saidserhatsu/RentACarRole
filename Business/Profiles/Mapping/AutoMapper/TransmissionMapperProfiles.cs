using AutoMapper;
using Business.Dtos.Model;
using Business.Dtos.Transmission;
using Business.Requests.TransmissionRequest;
using Business.Responses.TransmissionResponse;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class TransmissionMapperProfiles : Profile
    {
        public TransmissionMapperProfiles()
        {
            CreateMap<AddTransmissionRequest, Transmission>();
            CreateMap<Transmission, AddTransmissionResponse>();
            CreateMap<GetByIdTransmissionRequest, Transmission>();
            CreateMap<Transmission, GetByIdTransmissionResponse>();
            CreateMap<UpdateTransmissionRequest, Transmission>();
            CreateMap<Transmission, UpdateTransmissionResponse>();
            CreateMap<DeleteTransmissionRequest, Transmission>();
            CreateMap<Transmission, DeleteTransmissionResponse>();
            CreateMap<GetListTransmissionRequest, Transmission>();
            CreateMap<Transmission, TransmissionListItemDto>();
           
        }
    }
}

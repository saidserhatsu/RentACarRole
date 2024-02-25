using AutoMapper;
using Business.Dtos.Model;
using Business.Requests.ModelRequest;
using Business.Responses.ModelResponse;
using Entities.Concrete;


namespace Business.Profiles.Mapping.AutoMapper
{
    public class ModelMapperProfiles : Profile
    {
        public ModelMapperProfiles()
        {
            CreateMap<AddModelRequest, Model>();
            CreateMap<Model, AddModelResponse>();
            CreateMap<GetByIdModelRequest, Model>();
            CreateMap<Model, GetByIdModelResponse>();
            CreateMap<UpdateModelRequest, Model>();
            CreateMap<Model, UpdateModelResponse>();
            CreateMap<DeleteModelRequest, Model>();
            CreateMap<Model, DeleteModelResponse>();
            CreateMap<GetListModelRequest, Model>();
            CreateMap<Model, ModelListItemDto>();
            CreateMap<IList<Model>, GetListModelResponse>()
                .ForMember(destinationMember: dest => dest.Items,
                           memberOptions: opt => opt.MapFrom(mapExpression: src => src));
        }
    }
}

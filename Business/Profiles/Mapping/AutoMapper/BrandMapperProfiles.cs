using AutoMapper;
using Business.Requests.BrandRequest;
using Business.Responses.BrandResponse;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class BrandMapperProfiles :Profile
    {
        public BrandMapperProfiles()
        {
            CreateMap<AddBrandRequest, Brand>();
            CreateMap<Brand, AddBrandResponse>();
            CreateMap<Brand,BrandListItemDto>();
            CreateMap<IList<Brand>, GetListBrandResponse>()
                .ForMember(destinationMember: dest => dest.Items,
                           memberOptions: opt => opt.MapFrom(mapExpression: src => src));               
        }
    }
}

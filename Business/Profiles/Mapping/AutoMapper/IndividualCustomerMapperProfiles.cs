using AutoMapper;
using Business.Requests.IndividualCustomerRequest;
using Business.Responses.IndividualCustomerResponse;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class IndividualCustomerMapperProfiles : Profile
    {
        public IndividualCustomerMapperProfiles()
        {
            CreateMap<AddIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, AddIndividualCustomerResponse>();
            CreateMap<GetByIdIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, GetByIdIndividualCustomerResponse>();
            CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();
            CreateMap<DeleteIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, DeleteIndividualCustomerResponse>();
            CreateMap<GetListIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, IndividualCustomerListItemDto>();
            CreateMap<IList<IndividualCustomer>, GetListIndividualCustomerResponse>()
                .ForMember(destinationMember: dest => dest.Items,
                           memberOptions: opt => opt.MapFrom(mapExpression: src => src));
        }
    }
}

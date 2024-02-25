using AutoMapper;
using Business.Dtos.Customer;
using Business.Requests.CustomerRequest;
using Business.Requests.UserRequest;
using Business.Responses.CustomerResponse;
using Business.Responses.UserResponse;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class CustomerMapperProfiles : Profile
    {
        public CustomerMapperProfiles()
        {
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<Customer, AddCustomerResponse>();
            CreateMap<GetByIdCustomerRequest, Customer>();
            CreateMap<Customer, GetByIdCustomerResponse>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<Customer, UpdateCustomerResponse>();
            CreateMap<DeleteCustomerRequest, Customer>();
            CreateMap<Customer, DeleteCustomerResponse>();
            CreateMap<GetListCustomerRequest, Customer>();
            CreateMap<Customer, CustomerListItemDto>();
            CreateMap<IList<Customer>, GetListCustomerResponse>()
                .ForMember(destinationMember: dest => dest.Items,
                           memberOptions: opt => opt.MapFrom(mapExpression: src => src));
        }
    }
}

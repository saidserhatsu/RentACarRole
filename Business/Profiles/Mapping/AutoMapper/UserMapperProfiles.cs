using AutoMapper;
using Business.Requests.UserRequest;
using Business.Responses.UserResponse;
using Core.Entities;
using Entities.Concrete;


namespace Business.Profiles.Mapping.AutoMapper
{
    public class UserMapperProfiles :Profile
    {
        public UserMapperProfiles()
        {
            CreateMap<AddUserRequest, User>();
            CreateMap<User, AddUserResponse>();
            CreateMap<GetByIdUserRequest, User>();
            CreateMap<User, GetByIdUserResponse>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UpdateUserResponse>();
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, DeleteUserResponse>();
            CreateMap<GetListUserRequest, User>();
            CreateMap<User, UserListItemDto>();
            CreateMap<IList<User>, GetListUserResponse>()
                .ForMember(destinationMember: dest => dest.Items,
                           memberOptions: opt => opt.MapFrom(mapExpression: src => src));
        }
    }
}

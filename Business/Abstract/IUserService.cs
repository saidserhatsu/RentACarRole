using Business.Requests.UserRequest;
using Business.Responses.UserResponse;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IUserService
    {
        /* public AddUserResponse Add(AddUserRequest addUserRequest);
         public GetListUserResponse GetList(GetListUserRequest getListUserRequest);
         public GetByIdUserResponse GetById(GetByIdUserRequest getByIdUserRequest);
         public UpdateUserResponse Update(UpdateUserRequest userRequest);
         public DeleteUserResponse Delete(DeleteUserRequest deleteUserRequest, bool isSoftDelete = true);*/
       void Register(RegisterRequest registerRequest);
       AccessToken Login(LoginRequest loginRequest);
    }
}

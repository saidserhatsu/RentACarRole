using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Profiles.Validation.FluentValidation.User;
using Business.Requests.UserRequest;
using Business.Responses.UserResponse;
using Core.CrossCuttingConcerns.NewFolder.FluentValidation;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using AccessToken = Core.Utilities.Security.JWT.AccessToken;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        public UserManager(IUserDal userdal, UserBusinessRules userBusinessRules, IMapper mapper, ITokenHelper tokenHelper)
        {
            this._userDal = userdal;
            this._userBusinessRules = userBusinessRules;
            this._mapper = mapper;
            this._tokenHelper = tokenHelper;

        }

        public AccessToken Login(LoginRequest loginRequest)
        {
            
            User? user = _userDal.Get(i => i.Email == loginRequest.Email);
            bool isPasswordCorrect = HashingHelper.VerifyPassword(loginRequest.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordCorrect)
            {
                throw new Exception("Password is wrong!");
            }
           
            return _tokenHelper.CreateToken(user);
        }

        public void Register(RegisterRequest registerRequest)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(registerRequest.Password, out passwordHash, out passwordSalt);
            User user = new User();
            user.Email = registerRequest.Email;
            user.Approved = false;           
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _userDal.Add(user);
        }

        /* public AddUserResponse Add(AddUserRequest userRequest)
         {
             ValidationTool.Validate(new AddUserRequestValidator(), userRequest);
             User user = _mapper.Map<User>(userRequest);
             _userDal.Add(user);
             AddUserResponse userResponse = _mapper.Map<AddUserResponse>(user);
             return userResponse;
         }
         public GetListUserResponse GetList(GetListUserRequest request)
         {
             IList<User> userList = _userDal.GetList(null);

             // mapping & response
             var response = _mapper.Map<GetListUserResponse>(userList);
             return response;
         }

         public GetByIdUserResponse GetById(GetByIdUserRequest getByIdUserRequest)
         {
             User? user = _userBusinessRules.FindUserWithId(getByIdUserRequest.Id);
             _userBusinessRules.CheckIfUserExists(user);
             GetByIdUserResponse userResponse = _mapper.Map<GetByIdUserResponse>(user);
             return userResponse;
         }

         public UpdateUserResponse Update(UpdateUserRequest userRequest)
         {
             User user = _userBusinessRules.FindUserWithId(userRequest.Id);
             _userBusinessRules.CheckIfUserExists(user);

             user = _mapper.Map(userRequest, user);
             User updatedUser = _userDal.Update(user);
             UpdateUserResponse userResponse = _mapper.Map<UpdateUserResponse>(updatedUser);
             return userResponse;
         }

         public DeleteUserResponse Delete(DeleteUserRequest deleteUserRequest, bool isSoftDelete = true)
         {
             User? user = _userBusinessRules.FindUserWithId(deleteUserRequest.Id);
             _userBusinessRules.CheckIfUserExists(user);
             User deletedUser = _userDal.Delete(user!);
             DeleteUserResponse userResponse = _mapper.Map<DeleteUserResponse>(deletedUser);
             return userResponse;
         }*/


    }
}

using Business;
using Business.Abstract;
using Business.Requests.UserRequest;
using Business.Responses.UserResponse;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public void Register([FromBody]RegisterRequest registerRequest)
        {
            _userService.Register(registerRequest);
        } 
        [HttpPost("Login")]
        public AccessToken Login([FromBody]LoginRequest loginRequest)
        {
            return _userService.Login(loginRequest);
        }

        /*
        [HttpGet]
        public GetListUserResponse GetList([FromQuery] GetListUserRequest request)
        {
            GetListUserResponse response = _userService.GetList(request);
            return response;
        }

        [HttpGet("{Id}")]
        public GetByIdUserResponse GetById([FromRoute] GetByIdUserRequest request)
        {
            GetByIdUserResponse response = _userService.GetById(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddUserResponse> Add(AddUserRequest request)
        {
            AddUserResponse response = _userService.Add(request);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },

                value: response
            );
        }

        [HttpPut("{Id}")]
        public ActionResult<UpdateUserResponse> Update(
            [FromRoute] int Id,
            [FromBody] UpdateUserRequest request
        )
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateUserResponse response = _userService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public DeleteUserResponse Delete([FromRoute] DeleteUserRequest request)
        {
            DeleteUserResponse response = _userService.Delete(request);
            return response;
        }
        */
    }
}

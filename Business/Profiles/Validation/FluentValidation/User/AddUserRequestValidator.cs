using Business.Requests.UserRequest;
using FluentValidation;
namespace Business.Profiles.Validation.FluentValidation.User
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {

        }
    }
}

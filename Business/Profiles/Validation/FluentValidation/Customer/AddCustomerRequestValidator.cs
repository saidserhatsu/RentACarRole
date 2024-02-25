using Business.Requests.CustomerRequest;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.Customer
{
    public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerRequestValidator() 
        {
            
        }

    }
}

using Business.Abstract;
using Business.Requests.CustomerRequest;
using Business.Requests.UserRequest;
using Business.Responses.CustomerResponse;
using Business.Responses.UserResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public GetListCustomerResponse GetList([FromQuery] GetListCustomerRequest request)
        {
            GetListCustomerResponse response = _customerService.GetList(request);
            return response;
        }

        [HttpGet("{Id}")]
        public GetByIdCustomerResponse GetById([FromRoute] GetByIdCustomerRequest request)
        {
            GetByIdCustomerResponse response = _customerService.GetById(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddCustomerResponse> Add(AddCustomerRequest request)
        {
            AddCustomerResponse response = _customerService.Add(request);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },

                value: response
            );
        }

        [HttpPut("{Id}")]
        public ActionResult<UpdateCustomerResponse> Update(
            [FromRoute] int Id,
            [FromBody] UpdateCustomerRequest request
        )
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateCustomerResponse response = _customerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public DeleteCustomerResponse Delete([FromRoute] DeleteCustomerRequest request)
        {
            DeleteCustomerResponse response = _customerService.Delete(request);
            return response;
        }

    }
}

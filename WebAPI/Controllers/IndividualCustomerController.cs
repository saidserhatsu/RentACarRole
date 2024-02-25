using Business.Abstract;
using Business.Requests.IndividualCustomerRequest;
using Business.Responses.IndividualCustomerResponse;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomerController : Controller
    {
        private readonly IIndividualCustomerService _individualCustomerService;

        public IndividualCustomerController(IIndividualCustomerService individualCustomerService)
        {
            _individualCustomerService = individualCustomerService;
        }

        [HttpGet]
        public GetListIndividualCustomerResponse GetList([FromQuery] GetListIndividualCustomerRequest request)
        {
            GetListIndividualCustomerResponse response = _individualCustomerService.GetList(request);
            return response;
        }

        [HttpGet("{Id}")]
        public GetByIdIndividualCustomerResponse GetById([FromRoute] GetByIdIndividualCustomerRequest request)
        {
            GetByIdIndividualCustomerResponse response = _individualCustomerService.GetById(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddIndividualCustomerResponse> Add(AddIndividualCustomerRequest request)
        {
            AddIndividualCustomerResponse response = _individualCustomerService.Add(request);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },

                value: response
            );
        }

        [HttpPut("{Id}")]
        public ActionResult<UpdateIndividualCustomerResponse> Update(
            [FromRoute] int Id,
            [FromBody] UpdateIndividualCustomerRequest request
        )
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateIndividualCustomerResponse response = _individualCustomerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public DeleteIndividualCustomerResponse Delete([FromRoute] DeleteIndividualCustomerRequest request)
        {
            DeleteIndividualCustomerResponse response = _individualCustomerService.Delete(request);
            return response;
        }


    }
        
}

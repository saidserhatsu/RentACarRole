using Business.Abstract;
using Business.Requests.TransmissionRequest;
using Business.Responses.TransmissionResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {


        private readonly ITransmissionService _transmissionService;
        public TransmissionController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;


        }
        [HttpGet]
        public ICollection<AddTransmissionResponse> GetList()
        {
            IList<AddTransmissionResponse> transmissionlist = _transmissionService.GetList();
            return transmissionlist;
        }


        [HttpGet("{id}")]
        public AddTransmissionResponse GetById(int id)
        {
            AddTransmissionResponse transmissionResponse = _transmissionService.GetById(id);
            return transmissionResponse;
        }
        [HttpPut("{id}")]
        public AddTransmissionResponse Add(AddTransmissionRequest addTransmissionRequest, int id)
        {
            AddTransmissionResponse transmissionResponse = _transmissionService.Update(id, addTransmissionRequest);
            return transmissionResponse;
        }


        [HttpPost]
        public AddTransmissionResponse Add(AddTransmissionRequest addtransmissionRequest)
        {
            AddTransmissionResponse transmissionResponse = _transmissionService.Add(addtransmissionRequest);
            return transmissionResponse;
        }
        [HttpDelete("{id}")]
        public AddTransmissionResponse Delete(int id)
        {
            AddTransmissionResponse transmissionResponse = _transmissionService.Delete(id);
            return transmissionResponse;
        }


    }
}

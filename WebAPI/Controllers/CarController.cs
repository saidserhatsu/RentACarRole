using Business;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;


        }
        [HttpPost]
        public AddCarResponse Add(AddCarRequest addCarRequest)
        {
            AddCarResponse carResponse = _carService.Add(addCarRequest);
            return carResponse;
        }
        [HttpGet]
        public GetListCarResponse GetList([FromQuery] GetListCarRequest getListCarRequest)
        {
            GetListCarResponse carlist = _carService.GetList(getListCarRequest);
            return carlist;
        }


        [HttpGet("{id}")]
        public GetByIdCarResponse GetById(int id)
        {
            GetByIdCarResponse carResponse = _carService.GetById(id);
            return carResponse;
        }
        [HttpPut("{id}")]
        public UpdateCarResponse Add(UpdateCarRequest updateCarRequest, int id)
        {
            UpdateCarResponse carResponse = _carService.Update(id, updateCarRequest);
            return carResponse;
        }



        [HttpDelete("{id}")]
        public DeleteCarResponse Delete(int id)
        {
            DeleteCarResponse carResponse = _carService.Delete(id);
            return carResponse;
        }


    }
}

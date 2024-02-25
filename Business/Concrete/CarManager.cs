using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.BrandRequest;
using Business.Responses.BrandResponse;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
        private readonly ICarDal _carDal;
        private readonly CarBusinessRules _carBusinessRules;
        private readonly IMapper _mapper;
        public CarManager(ICarDal carDal, CarBusinessRules carBusinessRules, IMapper mapper)
        {
            _carDal = carDal;
            _carBusinessRules = carBusinessRules;
            _mapper = mapper;
        }

        public AddCarResponse Add(AddCarRequest carRequest)
        {
            _carBusinessRules.CheckIfCarPlateAlreadyExists(carRequest.Plate);
            Model model=_carBusinessRules.FindCarWithModelId(carRequest.ModelId);

            Car car = _mapper.Map<Car>(carRequest);
            car.model = model;
            _carDal.Add(car);
            AddCarResponse carResponse = _mapper.Map<AddCarResponse>(car);
            return carResponse;
        }

   

        public GetByIdCarResponse GetById(int id)
        {
            Car car= _carBusinessRules.FindCarWithId(id);
            if (car == null)
            {
                throw new Exception("Car is not exists...");
            }
            GetByIdCarResponse carResponse = _mapper.Map<GetByIdCarResponse>(car);
            return carResponse;
        }

        public UpdateCarResponse Update(int id, UpdateCarRequest carRequest)
        {
            Car car = _carBusinessRules.FindCarWithId(id);
            car.Plate = carRequest.Plate;
            car.UpdateAt = DateTime.Now;
            UpdateCarResponse carResponse = _mapper.Map<UpdateCarResponse>(car);
            return carResponse;
        }

        public DeleteCarResponse Delete(int id)
        {
            Car car = _carBusinessRules.FindCarWithId(id);
            car.DeletedAt = DateTime.Now;
            DeleteCarResponse carResponse = _mapper.Map<DeleteCarResponse>(car);
            return carResponse;
        }

        public GetListCarResponse GetList(GetListCarRequest request)
        {
            //check
            IList<Car> list = new List<Car>();
            GetListCarResponse getListCarResponse = _mapper.Map<GetListCarResponse>(list);
            return getListCarResponse;
        }
    }
}

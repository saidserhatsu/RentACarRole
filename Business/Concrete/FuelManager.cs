using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.FuelRequest;
using Business.Responses.FuelResponse;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        private IFuelDal _fuelDal;
        private FuelBusinessRules _fuelBusinessRules;
        private IMapper _mapper;

        public FuelManager(IFuelDal fuelDal, FuelBusinessRules fuelBusinessRules, IMapper mapper)
        {
            this._fuelDal = fuelDal;
            this._mapper = mapper;
            this._fuelBusinessRules = fuelBusinessRules;
        }

        public AddFuelResponse Add(AddFuelRequest addFuelRequest)
        {
            _fuelBusinessRules.CheckFuelTypeName(addFuelRequest.FuelTypeName);
            _fuelBusinessRules.CheckIfBrandNameAlreadyExists(addFuelRequest.FuelTypeName);
            Fuel fuel = _mapper.Map<Fuel>(addFuelRequest);
            _fuelDal.Add(fuel);
            AddFuelResponse addFuelResponse = _mapper.Map<AddFuelResponse>(fuel);
            return addFuelResponse;
        }

        public DeleteFuelResponse Delete(int id)
        {
            Fuel fuel = _fuelBusinessRules.FindFuelWithId(id);
            fuel.DeletedAt = DateTime.Now;
            DeleteFuelResponse fuelResponse = _mapper.Map<DeleteFuelResponse>(fuel);
            return fuelResponse;
        }

        public GetByIdFuelResponse GetById(int id)
        {
            Fuel fuel = _fuelBusinessRules.FindFuelWithId(id);
            if (fuel == null)
            {
                throw new Exception("Fuel is not exists...");
            }
            GetByIdFuelResponse fuelResponse = _mapper.Map<GetByIdFuelResponse>(fuel);
            return fuelResponse;
        }

        public IList<AddFuelResponse> GetList()
        {
            //Check
            IList<Fuel> fuelList = new List<Fuel>();
            List<AddFuelResponse> fuelListResponse = new List<AddFuelResponse>();
            foreach (Fuel model in fuelList)
            {
                fuelListResponse.Add(_mapper.Map<AddFuelResponse>(model));

            }
            return fuelListResponse;
        }

        public AddFuelResponse Update(int id, AddFuelRequest fuelRequest)
        {
            Fuel fuel = _fuelBusinessRules.FindFuelWithId(id);
            fuel.FuelTypeName = fuelRequest.FuelTypeName;
            fuel.UpdateAt = DateTime.Now;
            AddFuelResponse fuelResponse = _mapper.Map<AddFuelResponse>(fuel);
            return fuelResponse;
        }

        public UpdateFuelResponse Update(int id, UpdateFuelRequest fuelRequest)
        {
            throw new NotImplementedException();
        }

        IList<GetListFuelResponse> IFuelService.GetList()
        {
            throw new NotImplementedException();
        }
    }
}

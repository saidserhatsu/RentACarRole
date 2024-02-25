using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.TransmissionRequest;
using Business.Responses.TransmissionResponse;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class TransmissionManager : ITransmissionService
    {
        private ITransmissionDal _transmissionDal;
        private TransmissionBusinessRules _transmissionBusinessRules;
        private IMapper _mapper;

        public TransmissionManager(ITransmissionDal transmissionDal, TransmissionBusinessRules transmissionBusinessRules, IMapper mapper)
        {
            this._transmissionDal = transmissionDal;
            this._mapper = mapper;
            this._transmissionBusinessRules = transmissionBusinessRules;
        }
        public AddTransmissionResponse Add(AddTransmissionRequest addTransmissionRequest)
        {
            _transmissionBusinessRules.CheckTransmissionTypeName(addTransmissionRequest.TransmissionTypeName);
            _transmissionBusinessRules.CheckIfTransmissionNameAlreadyExists(addTransmissionRequest.TransmissionTypeName);
            Transmission transmission = _mapper.Map<Transmission>(addTransmissionRequest);
            _transmissionDal.Add(transmission);
            AddTransmissionResponse addTransmissionResponse = _mapper.Map<AddTransmissionResponse>(transmission);
            return addTransmissionResponse;
        }

        public AddTransmissionResponse Delete(int id)
        {
            Transmission transmission = _transmissionBusinessRules.FindTransmissionWithId(id);
            transmission.DeletedAt = DateTime.Now;
            AddTransmissionResponse transmissionResponse = _mapper.Map<AddTransmissionResponse>(transmission);
            return transmissionResponse;
        }

        public AddTransmissionResponse GetById(int id)
        {
            Transmission transmission = _transmissionBusinessRules.FindTransmissionWithId(id);
            if (transmission == null)
            {
                throw new Exception("Fuel is not exists...");
            }
            AddTransmissionResponse transmissionResponse = _mapper.Map<AddTransmissionResponse>(transmission);
            return transmissionResponse;
        }

        public IList<AddTransmissionResponse> GetList()
        {
            IList<Transmission> transMissionList =new List<Transmission>();
            List<AddTransmissionResponse> transMissionListResponse = new List<AddTransmissionResponse>();
            foreach (Transmission model in transMissionList)
            {
                transMissionListResponse.Add(_mapper.Map<AddTransmissionResponse>(model));

            }
            return transMissionListResponse;
        }

        public AddTransmissionResponse Update(int id, AddTransmissionRequest transmissionRequest)
        {
            Transmission transmission = _transmissionBusinessRules.FindTransmissionWithId(id);
            transmission.TransmissionTypeName = transmissionRequest.TransmissionTypeName;
            transmission.UpdateAt = DateTime.Now;
            AddTransmissionResponse transMissionResponse = _mapper.Map<AddTransmissionResponse>(transmission);
            return transMissionResponse;
        }
    }
}

using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.IndividualCustomer;
using Business.Requests.IndividualCustomerRequest;
using Business.Responses.IndividualCustomerResponse;
using Core.CrossCuttingConcerns.NewFolder.FluentValidation;
using DataAccess.Abstract;

using Entities.Concrete;

namespace Business.Concrete
{
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
        private readonly IMapper _mapper;
        public IndividualCustomerManager(IIndividualCustomerDal individualCustomerdal, IndividualCustomerBusinessRules individualCustomerBusinessRules, IMapper mapper)
        {
            this._individualCustomerDal = individualCustomerdal;
            this._individualCustomerBusinessRules = individualCustomerBusinessRules;
            this._mapper = mapper;

        }

        public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest individualCustomerRequest)
        {
            ValidationTool.Validate(new AddIndividualCustomerValidator(), individualCustomerRequest);
            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(individualCustomerRequest);
            _individualCustomerDal.Add(individualCustomer);
            AddIndividualCustomerResponse individualCustomerResponse = _mapper.Map<AddIndividualCustomerResponse>(individualCustomer);
            return individualCustomerResponse;
        }
        public GetListIndividualCustomerResponse GetList(GetListIndividualCustomerRequest request)
        {
            IList<IndividualCustomer> individualCustomerList = _individualCustomerDal.GetList(null);

            // mapping & response
            var response = _mapper.Map<GetListIndividualCustomerResponse>(individualCustomerList);
            return response;
        }

        public GetByIdIndividualCustomerResponse GetById(GetByIdIndividualCustomerRequest getByIdIndividualCustomerRequest)
        {
            IndividualCustomer? individualCustomer = _individualCustomerBusinessRules.FindIndividualCustomerWithId(getByIdIndividualCustomerRequest.Id);
            _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomer);
            GetByIdIndividualCustomerResponse individualCustomerResponse = _mapper.Map<GetByIdIndividualCustomerResponse>(individualCustomer);
            return individualCustomerResponse;
        }

        public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest userRequest)
        {
            IndividualCustomer individualCustomer = _individualCustomerBusinessRules.FindIndividualCustomerWithId(userRequest.Id);
            _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomer);

            individualCustomer = _mapper.Map(userRequest, individualCustomer);
            IndividualCustomer updatedIndividualCustomer = _individualCustomerDal.Update(individualCustomer);
            UpdateIndividualCustomerResponse individualCustomerResponse = _mapper.Map<UpdateIndividualCustomerResponse>(updatedIndividualCustomer);
            return individualCustomerResponse;
        }

        public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest deleteIndividualCustomerRequest, bool isSoftDelete = true)
        {
            IndividualCustomer? individualCustomer = _individualCustomerBusinessRules.FindIndividualCustomerWithId(deleteIndividualCustomerRequest.Id);
            _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomer);
            IndividualCustomer deletedIndividualCustomer = _individualCustomerDal.Delete(individualCustomer!);
            DeleteIndividualCustomerResponse individualCustomerResponse = _mapper.Map<DeleteIndividualCustomerResponse>(deletedIndividualCustomer);
            return individualCustomerResponse;
        }

       
    }
}

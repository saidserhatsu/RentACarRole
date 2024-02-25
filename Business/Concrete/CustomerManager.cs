using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Customer;
using Business.Requests.CustomerRequest;
using Business.Responses.CustomerResponse;
using Core.CrossCuttingConcerns.NewFolder.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal customerdal, CustomerBusinessRules customerBusinessRules, IMapper mapper)
        {
            this._customerDal = customerdal;
            this._customerBusinessRules = customerBusinessRules;
            this._mapper = mapper;

        }
        public AddCustomerResponse Add(AddCustomerRequest addCustomerRequest)
        {
            ValidationTool.Validate(new AddCustomerRequestValidator(), addCustomerRequest);
            Customer customer = _mapper.Map<Customer>(addCustomerRequest);
            _customerDal.Add(customer);
            AddCustomerResponse customerResponse = _mapper.Map<AddCustomerResponse>(customer);
            return customerResponse;
        }

        public DeleteCustomerResponse Delete(DeleteCustomerRequest deleteCustomerRequest, bool isSoftDelete = true)
        {
            Customer? customer = _customerBusinessRules.FindCustomerWithId(deleteCustomerRequest.Id);
            _customerBusinessRules.CheckIfCustomerExists(customer);
            Customer deletedCustomer = _customerDal.Delete(customer!);
            DeleteCustomerResponse customerResponse = _mapper.Map<DeleteCustomerResponse>(deletedCustomer);
            return customerResponse;
        }

        public GetByIdCustomerResponse GetById(GetByIdCustomerRequest getByIdCustomerRequest)
        {
            Customer? customer = _customerBusinessRules.FindCustomerWithId(getByIdCustomerRequest.Id);
            _customerBusinessRules.CheckIfCustomerExists(customer);
            GetByIdCustomerResponse customerResponse = _mapper.Map<GetByIdCustomerResponse>(customer);
            return customerResponse;
        }

        public GetListCustomerResponse GetList(GetListCustomerRequest getListCustomerRequest)
        {
            IList<Customer> customerList = _customerDal.GetList(null);

            // mapping & response
            var response = _mapper.Map<GetListCustomerResponse>(customerList);
            return response;
        }

        public UpdateCustomerResponse Update(UpdateCustomerRequest customerRequest)
        {
            Customer customer = _customerBusinessRules.FindCustomerWithId(customerRequest.Id);
            _customerBusinessRules.CheckIfCustomerExists(customer);
            customer = _mapper.Map(customerRequest, customer);
            Customer updatedCustomer = _customerDal.Update(customer);
            UpdateCustomerResponse customerResponse = _mapper.Map<UpdateCustomerResponse>(updatedCustomer);
            return customerResponse;
        }
    }
}

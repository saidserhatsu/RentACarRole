using Business.Requests.CustomerRequest;
using Business.Responses.CustomerResponse;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public AddCustomerResponse Add(AddCustomerRequest addCustomerRequest);
        public GetListCustomerResponse GetList(GetListCustomerRequest getListCustomerRequest);
        public GetByIdCustomerResponse GetById(GetByIdCustomerRequest getByIdCustomerRequest);
        public UpdateCustomerResponse Update(UpdateCustomerRequest customerRequest);
        public DeleteCustomerResponse Delete(DeleteCustomerRequest deleteCustomerRequest, bool isSoftDelete = true);
    }
}

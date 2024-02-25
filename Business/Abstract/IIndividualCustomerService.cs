using Business.Requests.IndividualCustomerRequest;
using Business.Responses.IndividualCustomerResponse;
namespace Business.Abstract
{
    public interface IIndividualCustomerService
    {
        public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest addIndividualCustomerRequest);
        public GetListIndividualCustomerResponse GetList(GetListIndividualCustomerRequest getListIndividualCustomerRequest);
        public GetByIdIndividualCustomerResponse GetById(GetByIdIndividualCustomerRequest getByIdIndividualCustomerRequest);
        public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest individualCustomerRequest);
        public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest deleteIndividualCustomerRequest, bool isSoftDelete = true);
    }
}

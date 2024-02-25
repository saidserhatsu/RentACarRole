using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerDal _customerDal;
        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        public Customer FindCustomerWithId(int id)
        {
            Customer customer = _customerDal.Get(predicate: e => e.Id == id);

            return customer;
        }
        public void CheckIfCustomerExists(Customer? customer)
        {

            if (customer == null)
            {
                throw new NotFoundException("Customer not found...");
            }
        }
    }
}

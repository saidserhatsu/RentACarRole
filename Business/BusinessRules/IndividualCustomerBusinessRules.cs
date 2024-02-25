using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;
        public IndividualCustomerBusinessRules(IIndividualCustomerDal individualCustomerDal)
        {
            _individualCustomerDal = individualCustomerDal;
        }


        public IndividualCustomer FindIndividualCustomerWithId(int id)
        {
            IndividualCustomer individualCustomer = _individualCustomerDal.Get(predicate: e => e.Id == id);

            return individualCustomer;
        }
        public void CheckIfIndividualCustomerExists(IndividualCustomer? individualCustomer)
        {

            if (individualCustomer == null)
            {
                throw new NotFoundException("IndividualCustomer not found...");
            }
        }

    }
}

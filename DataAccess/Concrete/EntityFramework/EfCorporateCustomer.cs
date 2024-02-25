
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCorporateCustomer : EfEntityRepositoryBase<CorporateCustomer, int, RentACarContext>, ICorporateCustomerDal
    {
        public EfCorporateCustomer(RentACarContext context) : base(context)
        {
        }
    }
}

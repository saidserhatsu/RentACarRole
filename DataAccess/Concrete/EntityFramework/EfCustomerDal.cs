using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, int, RentACarContext>, ICustomerDal
    {
        public EfCustomerDal(RentACarContext context) : base(context)
        {
        }
    }
}


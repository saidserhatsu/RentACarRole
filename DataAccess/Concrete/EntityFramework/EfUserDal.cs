using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
namespace DataAccess.Concrete.EntityFramework
{

    public class EfUserDal : EfEntityRepositoryBase<User, int, RentACarContext>, IUserDal
    {
        public EfUserDal(RentACarContext context) : base(context)
        {
        }
    }
}

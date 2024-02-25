using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;
public class EfBrandDal : EfEntityRepositoryBase<Brand, int, RentACarContext>, IBrandDal
{
    public EfBrandDal(RentACarContext context) : base(context)
    {
    }
}

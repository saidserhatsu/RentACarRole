using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;


    public class BrandBusinessRules
    {
        private readonly IBrandDal _branDal;
        public BrandBusinessRules(IBrandDal branDal)
        {
            _branDal = branDal;
        }
        public void CheckIfBrandNameAlreadyExists(string brandName)
        {
          
        }

        public Brand FindBrandWithId(int id)
        {
        Brand brand = new();
            return brand;
        }
    }


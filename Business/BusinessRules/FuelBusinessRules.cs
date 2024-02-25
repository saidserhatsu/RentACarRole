using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.BusinessRules
{
    public class FuelBusinessRules
    {
        private readonly IFuelDal _fuelDal;
        public FuelBusinessRules(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }
        public void CheckIfBrandNameAlreadyExists(string fuelTypeName)
        {
          
        }
        public void CheckFuelTypeName(string fuelType)
        {
            List<string> fuelTypes = new() { "Gasoline", "Diesel", "Gas", "Electric" };
            bool isContain = fuelTypes.Contains(fuelType);
            if (!isContain)
            {
                throw new Exception("Invalid Fuel Type...");
            }

        }

        public Fuel FindFuelWithId(int id)
        {
            //check
            Fuel fuel = new();
            return fuel;
        }
    }
}

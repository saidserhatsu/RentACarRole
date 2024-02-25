using Core.Entities;

namespace Entities.Concrete;

public class Model : Entity<int>
{
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public int DailyPrice { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }

    public Brand? Brand { get; set; } = null;
    public Fuel? Fuel{ get; set; } = null;
    public Transmission? Transmission { get; set; } = null;
    public ICollection<Car> Cars { get; set; }

    public Model()
    {
        
    }

    public Model(int brandId, int fuelId, int transmissionId, int dailyPrice, string name, short year, ICollection<Car> cars)
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        DailyPrice = dailyPrice;
        Name = name;
        Year = year;
        Cars = cars;
    }
}

using Entities.Concrete;

namespace Business
{
    public class AddCarRequest
    {
        public string Plate { get; set; }
        public int ModelId { get; set; }
        public int Kilometer { get; set; }
        public string CarState { get; set; }

     
    }
}
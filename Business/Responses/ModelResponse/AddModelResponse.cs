using Entities.Concrete;


namespace Business.Responses.ModelResponse
{
    public class AddModelResponse
    {

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int TransmissonId { get; set; }
        public int FuelId { get; set; }

        public string? Name { get; set; }
        public short Year { get; set; }
        public int DailyPrice { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}

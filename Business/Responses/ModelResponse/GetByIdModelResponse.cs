namespace Business.Responses.ModelResponse
{
    public class GetByIdModelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }
        public int DailyPrice { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int FuelId { get; set; }
        public string FuelName { get; set; }
        public int TransmissionId { get; set; }
        public string TransmissionName { get; set; }
    }
}
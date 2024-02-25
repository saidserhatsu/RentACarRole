namespace Business
{
    public class UpdateModelRequest
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public int DailyPrice { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }
        
    }
}
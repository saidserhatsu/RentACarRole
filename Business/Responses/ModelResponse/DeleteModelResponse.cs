namespace Business.Responses.ModelResponse
{
    public class DeleteModelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
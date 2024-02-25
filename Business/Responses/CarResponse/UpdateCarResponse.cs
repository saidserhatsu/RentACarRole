namespace Business
{
    public class UpdateCarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }

        public UpdateCarResponse(int id, string name, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            UpdateAt = updatedAt;
        }
    }
}
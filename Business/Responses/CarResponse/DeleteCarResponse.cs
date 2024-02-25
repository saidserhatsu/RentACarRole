namespace Business
{
    public class DeleteCarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeletedAt { get; set; }

        public DeleteCarResponse(int id, string name, DateTime deletedAt)
        {
            Id = id;
            Name = name;
            DeletedAt = deletedAt;
        }
    }
}
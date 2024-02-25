namespace Business.Responses.UserResponse
{
    public class DeleteUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
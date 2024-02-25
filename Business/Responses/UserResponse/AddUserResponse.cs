namespace Business.Responses.UserResponse
{
    public class AddUserResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
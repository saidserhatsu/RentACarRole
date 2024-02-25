namespace Business.Requests.IndividualCustomerRequest
{
    public class UpdateIndividualCustomerRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalIdentity { get; set; }
        public int CustomerId { get; set; }
    }
}
using Core.Entities;

namespace Entities.Concrete
{
    public class IndividualCustomer : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalIdentity { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IndividualCustomer()
        {
            
        }

        public IndividualCustomer(string firstName, string lastName,
        string email, string nationalIdentity, int customerId, Customer customer)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NationalIdentity = nationalIdentity;
            CustomerId = customerId;
            Customer = customer;
        }
    }
}

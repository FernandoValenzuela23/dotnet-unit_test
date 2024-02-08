namespace BusinessLogic
{
    public interface ICollectionSample
    {
        Customer? GetCustomerById(List<Customer> customers, int id);

    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}

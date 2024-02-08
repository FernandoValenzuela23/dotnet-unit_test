

namespace BusinessLogic
{
    public class CollectionSample : ICollectionSample
    {
        public CollectionSample()
        {
            
        }

        public Customer? GetCustomerById(List<Customer> customers, int id)
        {
            if(customers == null || customers.Count == 0)
            {
                return null;
            }

            return customers.FirstOrDefault(p => p.Id == id);
        }
    }
}

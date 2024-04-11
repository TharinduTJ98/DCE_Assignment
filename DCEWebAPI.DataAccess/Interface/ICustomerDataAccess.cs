using DCEWebAPI.Common.Models.Entities;


namespace DCEWebAPI.DataAccess.Interface
{
    public interface ICustomerDataAccess
    {
        void CreateCustomer(Customer customer);
        List<Customer> GetAllCustomer();
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid userId);
        List<Order> GetActiveOrderByCustomer(Guid customerId);
    }
}

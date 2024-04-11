using DCEWebAPI.Common.Models.Dtos;
using DCEWebAPI.Common.Models.Entities;


namespace DCEWebAPI.Business.Interface
{
    public interface ICustomerBusiness
    {
        void CreateCustomer(CustomerDto customerDto);
        List<Customer> GetAllCusomers();
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid UserId);
        List<Order> GetActiveOrderByCustomer(Guid OrderId);

    }
}

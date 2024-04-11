using DCEWebAPI.Business.Interface;
using DCEWebAPI.Common.Models.Dtos;
using DCEWebAPI.Common.Models.Entities;
using DCEWebAPI.DataAccess.Interface;


namespace DCEWebAPI.Business.CustomerBusiness
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerDataAccess _customerDataAccess;

        public CustomerBusiness(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public void CreateCustomer(CustomerDto createCustomerDto)
        {
            Customer customer = new Customer()
            {
                UserId = Guid.NewGuid(),
                IsActive = true,
                CreatedOn = DateTime.Now,
                Username = createCustomerDto.Username,
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Email = createCustomerDto.Email,
            };

            _customerDataAccess.CreateCustomer(customer);
        }

        public void DeleteCustomer(Guid UserId)
        {
            _customerDataAccess.DeleteCustomer(UserId);
        }

        public List<Order> GetActiveOrderByCustomer(Guid customerId)
        {
            return _customerDataAccess.GetActiveOrderByCustomer(customerId);
        }

        public List<Customer> GetAllCusomers()
        {
            return _customerDataAccess.GetAllCustomer();
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerDataAccess.UpdateCustomer(customer);
        }
    }
}

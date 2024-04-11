using DCEWebAPI.Common.Models.Entities;
using DCEWebAPI.DataAccess.Interface;
using Microsoft.Data.SqlClient;


namespace DCEWebAPI.DataAccess.CustomerDataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly string _connectionString;

        public CustomerDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateCustomer(Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Customer(UserId, Username, Email, FirstName, LastName, CreatedOn, IsActive) " +
                    "VAlUES(@UserId, @Username, @Email, @FirstName, @LastName, @CreatedOn, @IsActive)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", customer.UserId);
                command.Parameters.AddWithValue("@Username", customer.Username);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@CreatedOn", customer.CreatedOn);
                command.Parameters.AddWithValue("@IsActive", customer.IsActive);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Customer WHERE UserId = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public List<Order> GetActiveOrderByCustomer(Guid customerId)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Orders WHERE OrderBy = @CustomerId AND IsActive = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = (Guid)reader["OrderId"],
                        ProductId = (Guid)reader["ProductId"],
                        OrderStatus = (int)reader["OrderStatus"],
                        OrderType = (int)reader["OrderType"],
                        OrderBy = (Guid)reader["OrderBy"],
                        OrderedOn = (DateTime)reader["OrderedOn"],
                        ShippedOn = (DateTime)reader["ShippedOn"],
                        IsActive = (bool)reader["IsActive"]
                    };
                    orders.Add(order);
                }
            }

            return orders;
        }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        UserId = (Guid)reader["Userid"],
                        Username = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        CreatedOn = (DateTime)reader["CreatedOn"],
                        IsActive = (bool)reader["IsActive"]
                    };
                    customers.Add(customer);
                }
                return customers;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Customer SET Username = @Username, Email = @Email, FirstName = @FirstName, " +
                               "LastName = @LastName, CreatedOn = @CreatedOn, IsActive = @IsActive WHERE UserId = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", customer.Username);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@CreatedOn", customer.CreatedOn);
                command.Parameters.AddWithValue("@IsActive", customer.IsActive);
                command.Parameters.AddWithValue("@UserId", customer.UserId);

                connection.Open();
                command.ExecuteNonQuery();
            };

        }
    }
}

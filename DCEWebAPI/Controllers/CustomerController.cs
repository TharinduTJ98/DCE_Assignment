using DCEWebAPI.Business.Interface;
using DCEWebAPI.Common.Models.Dtos;
using DCEWebAPI.Common.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DCEWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusiness _customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _customerBusiness.CreateCustomer(customerDto);
                return Ok(customerDto);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            try
            {
                var customers = _customerBusiness.GetAllCusomers();
                return Ok(customers);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteCustomer(Guid userId)
        {
            try
            {
                _customerBusiness.DeleteCustomer(userId);
                var customer = _customerBusiness.GetAllCusomers();
                if(customer is null)
                {
                    return NotFound("There is no Customer");
                }
                else
                {
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                _customerBusiness.UpdateCustomer(customer);
                return Ok(customer);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("{customerId}")]
        public ActionResult<List<Order>> GetCustomer(Guid customerId)
        {
            try
            {
                var orders = _customerBusiness.GetActiveOrderByCustomer(customerId);
                if(orders is null)
                {
                    return NotFound("There is no Orders");
                }
                else
                {
                return Ok(orders);
                }
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}

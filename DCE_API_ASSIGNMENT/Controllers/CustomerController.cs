using DCE_API_ASSIGNMENT.DatabaseAccess;
using DCE_API_ASSIGNMENT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DCE_API_ASSIGNMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateCustomer([FromBody] Customer newCustomer)
        {
            try
            {
                if (newCustomer == null)
                {
                    return BadRequest("Invalid customer data.");
                }

                _db.Customer.Add(newCustomer);
                _db.SaveChanges();

                return Ok(newCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                // Retrieve all customers from the database
                List<Customer> customerList = _db.Customer.ToList();

                return Ok(customerList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost] 
        [Route("Update")]
        public IActionResult UpdateCustomer([FromBody] Customer updatedCustomer)
        {
            try
            {
                // Check if the provided customer data is valid
                if (updatedCustomer == null)
                {
                    return BadRequest("Invalid customer data.");
                }

                // Retrieve the existing customer from the database based on UserId
                Customer existingCustomer = _db.Customer.FirstOrDefault(c => c.UserId == updatedCustomer.UserId);

                // Check if the customer exists
                if (existingCustomer == null)
                {
                    return NotFound("Customer not found.");
                }

                // Update the customer's properties with the new values
                existingCustomer.Username = updatedCustomer.Username;
                existingCustomer.Email = updatedCustomer.Email;
                existingCustomer.FirstName = updatedCustomer.FirstName;
                existingCustomer.LastName = updatedCustomer.LastName;
                existingCustomer.IsActive = updatedCustomer.IsActive;

                _db.SaveChanges();

                return Ok("Customer updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                // Find the customer by ID
                Customer customerToDelete = _db.Customer.FirstOrDefault(c => c.UserId == id);

                if (customerToDelete == null)
                {
                    return NotFound("Customer not found.");
                }

                _db.Customer.Remove(customerToDelete);
                _db.SaveChanges();

                return Ok("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Active/{customerId}")]
        public async Task<IActionResult> GetActiveOrdersByCustomer(Guid customerId)
        {
            try
            {
                var parameter = new SqlParameter("@CustomerId", customerId);
                var activeOrders = await _db.Order.FromSqlRaw("EXEC GetActiveOrdersByCustomer @CustomerId", parameter).ToListAsync();

                return Ok(activeOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

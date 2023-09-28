using DCE_API_ASSIGNMENT.DatabaseAccess;
using DCE_API_ASSIGNMENT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Customer> customerList = new List<Customer>();
            customerList = _db.Customer.ToList();
            return Ok(customerList);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Customer customer)
        {
            _db.Add(customer);
            _db.SaveChanges();
            return Ok(customer);
        }



    }
}

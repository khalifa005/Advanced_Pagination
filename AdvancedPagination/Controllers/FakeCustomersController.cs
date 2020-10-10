using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedPagination.Core;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvancedPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeCustomersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public FakeCustomersController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        // GET: api/<FakeCustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            //var test = _context.Customers.AsAsyncEnumerable();
            return await _context.Customers.ToListAsync();
        }

        // GET api/<FakeCustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FakeCustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FakeCustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FakeCustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

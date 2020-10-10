using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedPagination.Core;
using AdvancedPagination.Core.Filter;
using AdvancedPagination.Core.Wrapper;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvancedPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeCustomersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public FakeCustomersController(IApplicationDbContext _context)
        {
            this._context = _context;
        }

        // GET: api/<FakeCustomersController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Customers
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize).ToListAsync();

            var totalRecord = await _context.Customers.CountAsync();

            var pagedResponse = new PagedResponse<List<Customer>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            
            return Ok(pagedResponse);
        }

        // GET api/<FakeCustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return Ok(new Response<Customer>(customer));
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

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AdvancedPagination.Core;
using AdvancedPagination.Core.Filter;
using AdvancedPagination.Core.Util;
using AdvancedPagination.Core.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace AdvancedPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeCustomersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IUriService _uriService;

        public FakeCustomersController(IApplicationDbContext _context, IUriService uriService)
        {
            this._context = _context;
            _uriService = uriService;
        }

        // GET: api/<FakeCustomersController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Customers
                .Skip((validFilter.PageNumber - Config.DefaultPageNumber) * validFilter.PageSize)
                .Take(validFilter.PageSize).ToListAsync();

            var route = Request.Path.Value;

            var totalRecord = await _context.Customers.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedResponse<Customer>(pagedData, validFilter, totalRecord, uriService:_uriService, route);
            
            return Ok(pagedResponse);
        }

        // GET api/<FakeCustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return Ok(new Response<Customer>(customer));
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AdvancedPagination.Core.CustomerHandler;
using AdvancedPagination.Core.Filter;
using MediatR;


namespace AdvancedPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersWithMediatorController : ControllerBase
    {
        private readonly IMediator _signal;

        public CustomersWithMediatorController(IMediator signal)
        {
            _signal = signal;
        }
        // GET: api/<CustomersWithMediatorController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var route = Request.Path.Value;

            var response = await _signal.Send(new GetCustomers.Request {Filter = validFilter, Route = route});
            return Ok(response);
        }

    }
}

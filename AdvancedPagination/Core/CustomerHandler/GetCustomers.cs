using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdvancedPagination.Core.Filter;
using AdvancedPagination.Core.Util;
using AdvancedPagination.Core.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AdvancedPagination.Core.CustomerHandler
{
    public class GetCustomers
    {
        public class Request : IRequest<Response>
        {
            public PaginationFilter Filter { get; set; }
            public string Route { get; set; }
        }

        public class Response 
        {
            public PagedResponse<List<Customer>> PagedResponse { get; set; }

            public Response(PagedResponse<List<Customer>> res)
            {
                PagedResponse = res;
            }

            public Response()
            {
                
            }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IApplicationDbContext _context;
            private readonly IUriService _uriService;

            public Handler(IApplicationDbContext context, IUriService uriService)
            {
                _context = context;
                _uriService = uriService;
            }
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                    var validFilter = new PaginationFilter(request.Filter.PageNumber, request.Filter.PageSize);

                    var pagedData = await _context.Customers
                        .Skip((validFilter.PageNumber - Config.DefaultPageNumber) * validFilter.PageSize)
                        .Take(validFilter.PageSize).ToListAsync(cancellationToken: cancellationToken);

                    var route = request.Route;

                    var totalRecord = await _context.Customers.CountAsync(cancellationToken: cancellationToken);

                    var pagedResponse = PaginationHelper.CreatePagedResponse<Customer>(pagedData, validFilter, totalRecord, uriService: _uriService, route);

                    return new Response(pagedResponse);
            }
        }
    }
}

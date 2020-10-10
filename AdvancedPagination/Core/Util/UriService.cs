using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedPagination.Core.Filter;
using Microsoft.AspNetCore.WebUtilities;

namespace AdvancedPagination.Core.Util
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
    public class UriService : IUriService
    {
        private readonly string _baseUrl;

        public UriService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var endPointUri = string.Concat(_baseUrl, route);
            var modifiedUri = QueryHelpers.AddQueryString(endPointUri.ToString(), Config.PageNumber, filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, Config.PageSize, filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}

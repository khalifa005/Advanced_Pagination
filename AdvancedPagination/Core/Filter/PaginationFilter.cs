using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedPagination.Core.Util;

namespace AdvancedPagination.Core.Filter
{
    public class PaginationFilter
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PaginationFilter()
        {
            this.PageNumber = Config.DefaultPageNumber;
            this.PageSize = Config.DefaultPageSize;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < Config.DefaultPageNumber ? Config.DefaultPageNumber : pageNumber;
            this.PageSize = pageSize > Config.DefaultPageSize ? Config.DefaultPageSize : pageSize;
        }
    }

    public class PagingInfo
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total results.
        /// </summary>
        /// <value>The total results.</value>
        public int TotalResults { get; set; }

        /// <summary>
        /// Gets the total number of pages
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (PageSize == 0)
                    return 1;

                int totalPages = Math.DivRem(TotalResults, PageSize, out int remainder);

                if (remainder > 0)
                    totalPages++;

                return totalPages;
            }
        }
    }
}

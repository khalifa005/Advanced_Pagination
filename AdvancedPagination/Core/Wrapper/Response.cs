using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AdvancedPagination.Core.Wrapper
{
    /// <summary>
    /// use this wrapper when return happen in the controller direct 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public Response()
        {
            
        }

        public Response(T data)
        {
            Data = data;
            Succeeded = true;
            Errors = null;
            Message = string.Empty;
            StatusCode = StatusCodes.Status200OK;
        }

        public T Data { get; set; }

        public string[] Errors { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }

        public int StatusCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AdvancedPagination.Core.Wrapper
{
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
        public Exception? Exception { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public bool IsOK
        {
            get => StatusCode == StatusCodes.Status200OK;
        }

    }
}

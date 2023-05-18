using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}

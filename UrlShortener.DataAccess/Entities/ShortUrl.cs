using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.DataAccess
{
    public class ShortUrl : BaseEntity
    {
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
    }
}

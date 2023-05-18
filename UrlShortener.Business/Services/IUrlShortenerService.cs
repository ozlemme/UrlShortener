using UrlShortener.Common;
using UrlShortener.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Business
{
    public interface IUrlShortenerService
    {
        string CreateShortUrl(CreateShortUrlRequest request);
        string GetOriginalUrl(GetOriginalUrlRequest request);
        string CreateCustomUrl(CreateCustomUrlRequest request);
    }
}

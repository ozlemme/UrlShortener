using UrlShortener.Common;
using UrlShortener.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Business
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly IUrlRepository _urlRepository;
        public UrlShortenerService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public string CreateShortUrl(CreateShortUrlRequest request)
        {
            var guid = GenerateGuid();

            _urlRepository.Add(request.OriginalUrl, guid);

            var url = new Uri(request.OriginalUrl);

            return $"{url.GetLeftPart(System.UriPartial.Authority)}/{guid}";
        }

        public string? GetOriginalUrl(GetOriginalUrlRequest request)
        {
            var url = new Uri(request.ShortUrl);

            return _urlRepository.GetByShort(url.AbsolutePath.Replace("/", ""));
        }

        public string CreateCustomUrl(CreateCustomUrlRequest request)
        {
            _urlRepository.Add(request.OriginalUrl, request.ShortCode);

            var url = new Uri(request.OriginalUrl);

            return $"{url.GetLeftPart(System.UriPartial.Authority)}/{request.ShortCode}";
        }

        public string GenerateGuid()
        {
            var alreadyExist = true;

            string guid = string.Empty;

            do
            {
                guid = Guid.NewGuid().ToString().Substring(0, 6);

                if (!_urlRepository.IsExist(guid))
                {
                    alreadyExist = false;
                }
            } while (alreadyExist);

            return guid;
        }
    }
}

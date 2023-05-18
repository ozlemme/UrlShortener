using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Business;
using UrlShortener.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UrlShortener.API
{
    public class UrlShortenerController : BaseController
    {
        private readonly IUrlShortenerService _urlShortenerService;
        public UrlShortenerController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public Response<string> Create(CreateShortUrlRequest request)
        {
            try
            {
                var response = _urlShortenerService.CreateShortUrl(request);

                return new Response<string> { Data = response, IsSuccess = true, Message = Messages.Success };
            }
            catch (Exception ex)
            {
                return new Response<string> { Data = null, IsSuccess = false, Message = Messages.Failed };
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public Response<string> Get(GetOriginalUrlRequest request)
        {
            try
            {
                var response = _urlShortenerService.GetOriginalUrl(request);

                return new Response<string> { Data = response, IsSuccess = true, Message = Messages.Success };
            }
            catch (Exception ex)
            {
                return new Response<string> { Data = null, IsSuccess = false, Message = Messages.Failed };
            }
        }

        [HttpPost]
        [Route("Custom")]
        [AllowAnonymous]
        public Response<string> CreateCustom(CreateCustomUrlRequest request)
        {
            try
            {
                var response = _urlShortenerService.CreateCustomUrl(request);

                return new Response<string> { Data = response, IsSuccess = true, Message = Messages.Success };
            }
            catch (Exception ex)
            {
                return new Response<string> { Data = null, IsSuccess = false, Message = Messages.Failed };
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Business;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.DataAccess;

namespace UrlShortener.Business
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUrlShortenerService, UrlShortenerService>();
            services.AddScoped<IUrlRepository,UrlRepository>();
        }
    }
}

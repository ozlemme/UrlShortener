using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.DataAccess
{
    public class UrlRepository : IUrlRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UrlRepository(DatabaseContext databaseContext,IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public int? Add(string originalUrl, string hash)
        {
            int? result = null;

            try
            {
                var entity = new ShortUrl { OriginalUrl = originalUrl, ShortCode = hash, CreatedDate = DateTime.Now };

                _databaseContext.Set<ShortUrl>().Add(entity);

                _databaseContext.SaveChanges();

                result = entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public string? GetByShort(string model)
        {
            return _databaseContext.ShortUrls.FirstOrDefault(x => x.ShortCode == model).OriginalUrl;
        }

        public bool IsExist(string model)
        {
            return _databaseContext.ShortUrls.Any(x => x.ShortCode == model);
        }
    }
}

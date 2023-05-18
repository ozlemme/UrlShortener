using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.DataAccess
{
    public interface IUrlRepository
    {
        int? Add(string url, string hash);
        string? GetByShort(string model);
        bool IsExist(string model);
    }
}

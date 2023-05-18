using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Common
{
    public class GetOriginalUrlRequest
    {
        [Required(ErrorMessage = "Short Code is required")]
        public string ShortUrl { get; set; }
    }
}

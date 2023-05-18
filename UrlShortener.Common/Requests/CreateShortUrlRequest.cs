using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Common
{
    public class CreateShortUrlRequest
    {
        [Required(ErrorMessage = "Original Url is required")]
        [RegularExpression(@"(http[s]?:\/\/)?[^\s([""<,>]*\.[^\s["",><]*", ErrorMessage = "Not valid url.")]
        public string OriginalUrl { get; set; }
    }
}

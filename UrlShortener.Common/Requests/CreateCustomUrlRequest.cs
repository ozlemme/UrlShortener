using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Common
{
    public class CreateCustomUrlRequest
    {
        [Required(ErrorMessage = "Original Url is required")]
        [RegularExpression(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$", ErrorMessage = "Not valid url.")]
        public string OriginalUrl { get; set; }

        [Required(ErrorMessage = "Short Code is required")]
        [StringLength(6, ErrorMessage = "Maximum characters exceeded")]
        public string ShortCode { get; set; }
    }
}

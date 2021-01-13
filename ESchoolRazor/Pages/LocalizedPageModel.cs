using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESchoolRazor.Pages
{
    public class LocalizedPageModel:PageModel
    {
        public IActionResult SetLanguage(string lang)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang, lang)),
                new CookieOptions { IsEssential = true, Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return Page();
        }

    }
}

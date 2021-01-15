using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
namespace ESchoolRazor.Pages
{
    public class LocalizedPageModel : PageModel
    {
        public IActionResult OnGetSelectLanguage(string lang)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang, lang)),
                new CookieOptions { IsEssential = true, Expires = new DateTimeOffset().AddYears(1) }
            );
            return Page();
        }
    }
}
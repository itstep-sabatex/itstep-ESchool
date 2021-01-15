using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ESchool.Models;
using System.IO;
using ESchoolRazor.Data;
using ESchoolRazor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;

namespace ESchoolRazor.Pages.Students
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<IndexModel> _localizer;
        private readonly ExportService _service;
        public IndexModel(ApplicationDbContext context, ExportService service, IStringLocalizer<IndexModel> localizer)
        {
            _context = context;
            _service = service;
            _localizer = localizer;
        }

        public IList<Student> Student { get; set; }
        public IList<ProfilePhoto> ProfilePhoto { get; set; }

        public IList<string> Filters { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NameSearch { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PhoneSearch { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EmailSearch { get; set; }
        [BindProperty]
        public int StudentsCount { get; set; }
        public async Task OnGetAsync(string NameSearch, string PhoneSearch, string EmailSearch)
        {
            Filters = new List<string>();
            var s1 = _context.Students.AsQueryable();
            if (!string.IsNullOrWhiteSpace(NameSearch))
            {
                s1 = s1.Where(f => f.Name.Contains(NameSearch));
                Filters.Add("Name");
            }
            if (!string.IsNullOrWhiteSpace(PhoneSearch))
            {
                s1 = s1.Where(f => f.PhoneNumber.Contains(PhoneSearch));
                Filters.Add("PhoneNumber");
            }
            if (!string.IsNullOrWhiteSpace(EmailSearch))
            {
                s1 = s1.Where(f => f.Email.Contains(EmailSearch));
                Filters.Add("Email");
            }
            StudentsCount = await s1.CountAsync();
            Student = await s1.Include(s => s.Photo).ToListAsync();
        }
        public IActionResult OnPost()
        {
            var content = _service.ExportToJson();
            return File(content, "application/json", "students.json");
        }
    }
}

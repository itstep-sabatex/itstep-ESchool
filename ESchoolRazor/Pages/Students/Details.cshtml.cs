using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ESchool.Models;
using ESchoolRazor.Data;
using Microsoft.AspNetCore.Authorization;

namespace ESchoolRazor.Pages.Students
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly ESchoolRazor.Data.ApplicationDbContext _context;

        public DetailsModel(ESchoolRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.Include(s => s.Photo).FirstOrDefaultAsync(m => m.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

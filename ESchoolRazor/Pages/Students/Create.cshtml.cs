using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ESchool.Models;
using ESchoolRazor.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ESchoolRazor.Pages.Students
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ESchoolRazor.Data.ApplicationDbContext _context;

        public CreateModel(ESchoolRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        [BindProperty]
        public UploadPhoto UploadPhoto { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (UploadPhoto.File != null)
            {
                using (var memory = new MemoryStream())
                {
                    await UploadPhoto.File.CopyToAsync(memory);
                    if (memory.Length < 2097152)
                    {
                        var file = new ProfilePhoto
                        {
                            Photo = memory.ToArray()
                        };
                        _context.ProfilePhotos.Add(file);
                        Student.Photo = file;
                        _context.Students.Add(Student);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else
            {
                var file = System.IO.File.OpenRead("/home/vitalik/Projects/NET/ESchool/ESchoolRazor/wwwroot/images/user.svg");
                using (var memory = new MemoryStream())
                {
                    await file.CopyToAsync(memory);
                    var photo = new ProfilePhoto
                    {
                        Photo = memory.ToArray()
                    };
                    _context.ProfilePhotos.Add(photo);
                    Student.Photo = photo;
                    _context.Students.Add(Student);
                    await _context.SaveChangesAsync();
                }

            }
            return RedirectToPage("./Index");
        }
    }

    public class UploadPhoto
    {
        public IFormFile File { get; set; }
    }
}

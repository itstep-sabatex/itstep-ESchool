using Microsoft.AspNetCore.Mvc.RazorPages;
using ESchoolRazor.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Collections.Generic;
using ESchool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESchoolRazor.Pages.Students
{
    public class ImportModel : PageModel
    {
        private readonly ImportService _service;

        public IFormFile ImportedFile { get; set; }
        public DesType[] DesTypes { get; set; }

        [BindProperty]
        public int TypeId { get; set; }

        public ImportModel(ImportService service)
        {
            _service = service;
            DesTypes = new DesType[]{
                new DesType{
                    Id = 1,
                    Type = typeof(Student)
                },
                new DesType{
                    Id = 2,
                    Type = typeof(ProfilePhoto)
                }
            };
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            await _service.ImportJson(ImportedFile, DesTypes[TypeId - 1].Type);
        }

    }
    public class DesType
    {
        public int Id { get; set; }
        public Type Type { get; set; }
    }
}
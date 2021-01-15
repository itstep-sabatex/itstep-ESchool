using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using ESchoolRazor.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ESchool.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ESchoolRazor.Services
{
    public class ExportService
    {
        private readonly ApplicationDbContext _context;

        public ExportService(ApplicationDbContext context)
        {
            _context = context;
        }
        public byte[] ExportToJson()
        {
            var students = _context.Students.Include(s => s.Photo).ToList();
            var data = JsonSerializer.Serialize(students, typeof(List<Student>), new JsonSerializerOptions
            {
                WriteIndented = true
            });
            var encoding = new UnicodeEncoding();
            byte[] bytesOfData = encoding.GetBytes(data);
            return bytesOfData;
        }

        // public IActionResult ExportToJsonSecond()
        // {
        //     var students = _context.Students.Include(s => s.Photo).ToList();
        //     var s = JsonSerializer.Serialize(students, new JsonSerializerOptions
        //     {
        //         WriteIndented = true
        //     });
        //     return s;
        // }
    }
}
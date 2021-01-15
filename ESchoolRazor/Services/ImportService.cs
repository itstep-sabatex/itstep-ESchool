using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Text.Json;
using ESchool.Models;
using ESchoolRazor.Data;

namespace ESchoolRazor.Services
{
    public class ImportService
    {

        private readonly ApplicationDbContext _context;

        public ImportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ImportJson(IFormFile file, Type type)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var data = await reader.ReadToEndAsync();
                using (var doc = JsonDocument.Parse(data))
                {
                    JsonElement root = doc.RootElement;

                    if (type == typeof(Student))
                    {
                        var students = new List<Student>();

                        foreach (var element in root.EnumerateArray())
                        {
                            students.Add(new Student
                            {
                                Name = element.GetProperty("Name").GetString(),
                                Email = element.GetProperty("Email").GetString(),
                                PhoneNumber = element.GetProperty("PhoneNumber").GetString()
                            });
                        }
                        await _context.Students.AddRangeAsync(students);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
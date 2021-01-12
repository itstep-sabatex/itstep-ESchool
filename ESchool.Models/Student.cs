using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ESchool.Models
{
    public class Student
    {
        public static List<Student> Students = new List<Student>(new Student[]
            {
                new Student
                {
                    Id=1,
                    Name="Іван Іванович Іванов",
                    BithDay = DateTime.Parse("01.11.1990"),
                    Email = "dranco@gmail.com",
                    PhoneNumber = "380556782345"

                },
                new Student
                {
                    Id=2,
                    Name="Іван Іванович Петров",
                    BithDay = DateTime.Parse("01.11.1989"),
                    Email = "dranco23@gmail.com",
                    PhoneNumber = "380556782344"

                }

            });

        public int Id { get; set; }
        [Display(Name = "Імя Прізвище ПоБатькові")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "День народження")]
        public DateTime BithDay { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        public FormOfEducation FormOfEducation { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

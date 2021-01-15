using System;
using System.ComponentModel.DataAnnotations;
namespace ESchool.Models
{
    public class Student
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Birthday")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Photo")]
        public ProfilePhoto Photo { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
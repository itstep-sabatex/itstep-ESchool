using System.ComponentModel.DataAnnotations;
namespace ESchool.Models
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        [Display(Name = "Profile Photo")]
        public byte[] Photo { get; set; }
    }
}
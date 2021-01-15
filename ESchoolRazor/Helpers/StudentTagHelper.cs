using ESchool.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ESchoolRazor.Helpers
{
    public class StudentTagHelper : TagHelper
    {
        public Student Student { get; set; }
        public bool IsHidden { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsHidden)
            {
                output.SuppressOutput();
            }
            else
            {
                output.TagName = "span";
                output.Content.Append($"{Student.Name} - {Student.BirthDay.ToShortDateString()}");
            }
        }
    }
}
using ESchool.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESchoolRazor.TagHelpers
{
    public class StudentTagHelper:TagHelper
    {
        public Student Student { get; set; }
        public bool IsHide { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsHide)
            {
                output.SuppressOutput();
            }
            else
            {

            }
        }
    }
}

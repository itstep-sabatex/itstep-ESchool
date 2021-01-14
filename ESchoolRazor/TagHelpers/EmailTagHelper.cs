using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESchoolRazor.TagHelpers
{
    [HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
    public class EmailTagHelper:TagHelper
    {
        // mail-to
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = MailTo + "@gmail.com";
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
            output.TagMode = TagMode.StartTagAndEndTag;

        }
    }
}

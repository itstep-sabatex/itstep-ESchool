using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ESchoolRazor.Helpers
{
    [HtmlTargetElement("bold")]
    [HtmlTargetElement(Attributes = "bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.TagName == "bold") output.TagName = "";
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");

        }
    }
}
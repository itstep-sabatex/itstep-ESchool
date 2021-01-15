using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;

namespace ESchoolRazor.Helpers
{
    [HtmlTargetElement("Email", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        private readonly IStringLocalizer<SharedResource> _localizer;
        public EmailTagHelper(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            var address = MailTo + "@gmail.com";
            output.Content.AppendLine(_localizer["For send mail click here"]);
            output.Content.AppendHtml($"<a href='mailto:{address}'>");
            output.Content.AppendLine(address);
            output.Content.AppendHtml("</a>");
        }
    }
}
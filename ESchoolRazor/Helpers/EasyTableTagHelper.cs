using System.Collections.Generic;
using ESchool.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Html;
using System.Linq;
using System;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ESchoolRazor.Helpers
{
    public class EasyTableTagHelper : TagHelper
    {
        public IEnumerable<Student> Students { get; set; }
        public bool IsAuth { get; set; }

        private readonly IStringLocalizer<SharedResource> _localizer;

        public EasyTableTagHelper(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Students.Count() > 0)
            {
                output.TagName = "table";
                output.Attributes.Add("class", "table table-bordered table-hover text-center shadow-sm");
                output.Content.AppendHtml("<thead>");
                output.Content.AppendHtml("<tr>");

                PropertyInfo[] propertyInfos = typeof(Student).GetProperties(); 

                foreach (PropertyInfo info in propertyInfos)
                {
                    DisplayAttribute attribute = (DisplayAttribute) info.GetCustomAttribute(typeof(DisplayAttribute));
                    output.Content.AppendHtml("<th scope='col'>");
                    output.Content.AppendHtmlLine($"<span style='white-space: nowrap;'>{_localizer[attribute.Name]}</span>");
                    output.Content.AppendHtml("</th>");
                }
                output.Content.AppendHtml("<th scope='col'>");
                output.Content.AppendHtmlLine($"<span style='white-space: nowrap;'>{_localizer["Actions"]}</span>");
                output.Content.AppendHtml("</th>");
                output.Content.AppendHtml("</tr>");
                output.Content.AppendHtml("</thead>");
                output.Content.AppendHtml("<tbody>");
                foreach (var student in Students)
                {
                    output.Content.AppendHtml("<tr>");
                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    output.Content.AppendHtml($"<span style='white-space: nowrap;'>{student.Id}</span>");
                    output.Content.AppendHtml("</td>");

                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    output.Content.AppendHtml($"<span style='white-space: nowrap;'>{student.Name}</span>");
                    output.Content.AppendHtml("</td>");

                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    output.Content.AppendHtml($"<span style='white-space: nowrap;'>{student.BirthDay.ToShortDateString()}</span>");
                    output.Content.AppendHtml("</td>");

                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    output.Content.AppendHtml($"<span style='white-space: nowrap;'>{student.PhoneNumber}</span>");
                    output.Content.AppendHtml("</td>");

                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    output.Content.AppendHtml($"<span style='white-space: nowrap;'>{student.Email}</span>");
                    output.Content.AppendHtml("</td>");

                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    if (student.Photo != null)
                    {
                        output.Content.AppendHtmlLine($"<img src='data:image/jpg;base64,{Convert.ToBase64String(student.Photo.Photo)}' height='50px' width='50px' alt='{student.Name}' class='rounded-circle shadow-sm' style='background-repeat: no-repeat; background-position: center; background-size: contain;object-fit:cover;' />");
                    }
                    else
                    {
                        output.Content.AppendHtmlLine($"<img src='/images/user.svg' height='50px' width='50px' alt='{student.Name}' class='rounded-circle shadow-sm' style='background-repeat: no-repeat; background-position: center; background-size: contain;object-fit:cover;' />");
                    }
                    output.Content.AppendHtml("</td>");
                    output.Content.AppendHtml("<td style='vertical-align: middle;'>");
                    output.Content.AppendHtmlLine($"<a href='/Students/Edit?id={student.Id}'>{_localizer["Edit"]}</a>");
                    output.Content.AppendHtmlLine($"<a href='/Students/Details?id={student.Id}'>{_localizer["Details"]}</a>");
                    output.Content.AppendHtmlLine($"<a href='/Students/Delete?id={student.Id}'>{_localizer["Delete"]}</a>");
                    output.Content.AppendHtml("</td>");
                    output.Content.AppendHtml("</tr>");
                }
                output.Content.AppendHtml("</tbody>");
                output.Content.AppendHtml("</table>");
            }
            else
            {
                output.TagName = "div";
                output.Attributes.Add("class", "my-5");
                output.Content.AppendHtmlLine($"<div class='text-center text-info'><h3>{_localizer["No Students"]}</h3></div>");
                output.Content.AppendHtmlLine($"<h5 class='text-center text-muted'><span>{_localizer["Be first student"]}</span> <a href='/Students/Create'>{_localizer["Create New"]}</a></h5>");
                if (IsAuth)
                {
                    output.Content.AppendHtmlLine($"<span>{_localizer["Or"]}</span>");
                    output.Content.AppendHtmlLine($"<a href='/Students/Import' class='btn btn-outline-dark shadow-sm px-4 py-2'>{_localizer["Import"]}</a>");
                }
            }
        }
    }
}
using Competence.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Competence.Infrastructure
{
    /// <summary>
    /// Custom tag helper class that builds a pagination tag helper for switching pages depending on the amount of content
    /// </summary>
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        /// <summary>
        /// Page link constructor that takes the UrlHelperFactory interface as a parameter and initializes it.
        /// </summary>
        /// <param name="helperFactory"></param>
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        /// <summary>
        /// View Context object
        /// </summary>
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        /// <summary>
        /// Page info view model object
        /// </summary>
        public PagingInfoViewModel PageModel { get; set; }
        /// <summary>
        /// Page action to indicate the action the page should call
        /// </summary>
        public string PageAction { get; set; }
        /// <summary>
        /// Page classes bool
        /// </summary>
        public bool PageClassesEnabled { get; set; } = false;
        /// <summary>
        /// Page class for btn
        /// </summary>
        public string PageClass { get; set; }
        /// <summary>
        /// Page class property
        /// </summary>
        public string PageClassNormal { get; set; }
        /// <summary>
        /// Page class property
        /// </summary>
        public string PageClassSelected { get; set; }

        /// <summary>
        /// Custom tag helper to display item on a new page.
        /// </summary>
        /// <param name="tagHelperContext"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext tagHelperContext, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new {page = i});
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}

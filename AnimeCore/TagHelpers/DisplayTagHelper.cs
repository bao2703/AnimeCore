using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AnimeCore.TagHelpers
{
    public class DisplayTagHelper : TagHelper
    {
        private const string NameForAttributeName = "name-for";

        [HtmlAttributeName(NameForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            var content = For.Metadata.GetDisplayName();

            output.TagName = null;
            output.Content.SetContent(content);
        }
    }
}
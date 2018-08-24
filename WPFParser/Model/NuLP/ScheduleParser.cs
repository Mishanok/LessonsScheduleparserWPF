using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace WPFParser.Model.NuLP
{
    class ScheduleParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("group_content"));

            foreach (var i in items)
            {
                list.Add(i.TextContent);
            }

            return list.ToArray();
        }
    }
}

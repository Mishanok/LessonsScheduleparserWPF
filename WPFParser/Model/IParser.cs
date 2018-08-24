using AngleSharp.Dom.Html;

namespace WPFParser.Model
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}

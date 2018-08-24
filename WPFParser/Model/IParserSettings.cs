namespace WPFParser.Model
{
    public interface IParserSettings
    {
        string BaseURL { get; set; }

        string Prefix { get; set; }

        int FirstPage { get; set; }

        int LastPage { get; set; }
    }
}

namespace WPFParser.Model.Habra
{
    public class HabreSettings : IParserSettings
    {
        public string BaseURL { get; set; } = "https://habr.com/";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int FirstPage { get; set; }
        public int LastPage { get ; set ; }

        public HabreSettings(int start, int end)
        {
            FirstPage = start;
            LastPage = end;
        }
    }
}

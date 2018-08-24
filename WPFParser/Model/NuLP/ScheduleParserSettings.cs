namespace WPFParser.Model.NuLP
{
    class ScheduleParserSettings : IParserSettings
    {
        public string BaseURL { get; set; } = "http://lp.edu.ua/students_schedule?institutecode_selective=%D0%86%D0%A2%D0%A0%D0%95&edugrupabr_selective=%D0%9C%D0%9D-31";
        public string Prefix { get; set; } = "";
        public int FirstPage { get ; set ; }
        public int LastPage { get ; set ; }
    }
}

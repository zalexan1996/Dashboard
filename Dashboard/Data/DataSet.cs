namespace Dashboard.Data
{
    public class DataSet
    {
        public string[] Data { get; set; } = { };
        public string Label { get; set; } = "Label";
        public string[] BackgroundColor { get; set; } = new string[] {"rgb(62,149,205,0.1)"};
        public string[] BorderColor { get; set; } = new string[] {"rgb(62, 149, 205)"};
        public int BorderWidth { get; set; } = 1;
    }
}

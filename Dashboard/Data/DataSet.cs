using DashboardAPI.Controllers.Knowbe4;

namespace Dashboard.Data
{
    public class DataSet
    {
        public string[] Data { get; set; } = { };
        public string Label { get; set; } = "Label";
        public string[] BackgroundColor { get; set; } = new string[] {"rgb(62,149,205,0.1)"};
        public string[] BorderColor { get; set; } = new string[] {"rgb(62, 149, 205)"};
        public int BorderWidth { get; set; } = 1;

        public bool Fill { get; set; } = false;
        public double Tension { get; set; } = 0.1;
        public string Stack { get; set; } = "combined";
        public string Type { get; set; } = "line";
   
    }
   
    
}

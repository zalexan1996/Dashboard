namespace Dashboard.Data
{

    public interface DataPoint
    {

        [Microsoft.AspNetCore.Components.ParameterAttribute]
        public string? Title {get; set;}

        [Microsoft.AspNetCore.Components.ParameterAttribute]
        public int RefreshInterval {get; set;}
    }
}
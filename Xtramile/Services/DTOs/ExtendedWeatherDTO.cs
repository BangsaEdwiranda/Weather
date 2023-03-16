namespace Xtramile.Services.DTOs
{
    public class ExtendedWeatherDTO
    {
        public string CityName { get; set; }
        public string Country { get; set; }
        public string TimeStamp { get; set; }
        public string WindSpeed { get; set; }
        public string WindDegree { get; set; }
        public string Visibility { get; set; }
        public string SkyDescription { get; set; }
        public string TemperatureInC { get; set; }
        public string TemperatureInF { get; set; }
        public string DewPoint { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
    }
}

namespace WeatherStationAPI.Configuration
{
    public class ValidationConfiguration
    {
        public int NameMaxcharacters { get; set; }
        public int LocationMaxCharacters { get; set; }
        public int WeatherStateMaxCharacters { get; set; }
        public string LocationRegex { get; set; }
        public string IsTextOnlyRegex { get; set; }
        public string IsValidUrlRegex { get; set; }
        public string IsIntegerNumberRegex { get; set; }

    }
}

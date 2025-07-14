namespace WorldCitiesAPI.Models
{
    public class WorldCity
    {
        public int CityId { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Population { get; set; }
    }
}


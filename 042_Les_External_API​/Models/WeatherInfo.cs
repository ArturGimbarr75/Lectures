namespace _042_Les_External_API​.Models
{
	public class WeatherInfo
	{
		public int queryCost { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
		public string resolvedAddress { get; set; }
		public string address { get; set; }
		public string timezone { get; set; }
		public double tzoffset { get; set; }
		public string description { get; set; }
		public List<Day> days { get; set; }
		public List<object> alerts { get; set; }
		public Stations stations { get; set; }
		public CurrentConditions currentConditions { get; set; }
	}
}

namespace _042_Les_External_API​.Models
{
	public class CurrentConditions
	{
		public string datetime { get; set; }
		public int datetimeEpoch { get; set; }
		public double temp { get; set; }
		public double feelslike { get; set; }
		public double humidity { get; set; }
		public double dew { get; set; }
		public double precip { get; set; }
		public double precipprob { get; set; }
		public double snow { get; set; }
		public double snowdepth { get; set; }
		public object preciptype { get; set; }
		public double windgust { get; set; }
		public double windspeed { get; set; }
		public double winddir { get; set; }
		public double pressure { get; set; }
		public double visibility { get; set; }
		public double cloudcover { get; set; }
		public double solarradiation { get; set; }
		public double solarenergy { get; set; }
		public double uvindex { get; set; }
		public string conditions { get; set; }
		public string icon { get; set; }
		public List<string> stations { get; set; }
		public string source { get; set; }
		public string sunrise { get; set; }
		public double sunriseEpoch { get; set; }
		public string sunset { get; set; }
		public double sunsetEpoch { get; set; }
		public double moonphase { get; set; }
	}
}

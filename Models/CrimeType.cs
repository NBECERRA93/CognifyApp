namespace CognifyApp.Models
{
    public class Memory
    {
        public string Description { get; set; }
        public string Intensity { get; set; }
        public string Duration { get; set; }
        public CrimeType CrimeType { get; set; }
    }

    public enum CrimeType
    {
        Violent,
        Theft
    }
}

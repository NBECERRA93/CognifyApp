namespace Cognify.Models
{
    public class Memory
    {
        public string Description { get; set; }
        public string Intensity { get; set; }
        public string Duration { get; set; }

        // Añadimos la propiedad CrimeType
        public CrimeType CrimeType { get; set; }
    }

    // Definimos un enumerado para los tipos de crimen
    public enum CrimeType
    {
        Violent,
        Theft
    }
}

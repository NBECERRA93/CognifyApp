namespace Cognify.Models.Factory
{
    public class TheftCrimeMemoryFactory : MemoryFactory
    {
        // Implementamos CreateMemory con los parámetros necesarios
        public override Memory CreateMemory(string description, string intensity, string duration)
        {
            return new Memory
            {
                Description = description,
                Intensity = intensity,
                Duration = duration,
                CrimeType = CrimeType.Theft  // Asignamos el tipo de crimen Robo
            };
        }
    }
}

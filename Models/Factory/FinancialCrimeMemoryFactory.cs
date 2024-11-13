namespace Cognify.Models.Factory
{
    public class FinancialCrimeMemoryFactory : MemoryFactory
    {
        // Implementación del método CreateMemory para crímenes financieros
        public override Memory CreateMemory(string description, string intensity, string duration)
        {
            // Personalización del recuerdo según el crimen financiero
            return new Memory
            {
                Description = "Financial crime memory: " + description,
                Intensity = intensity ?? "Medium",
                Duration = duration ?? "Short-term"
            };
        }
    }
}

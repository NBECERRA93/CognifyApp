namespace Cognify.Models
{
    public class Simulation
    {
        public List<Memory> Memories { get; set; }
        public string CrimeType { get; set; }
        public string ImpactEvaluation { get; set; } // Evaluación del impacto

        public Simulation(string crimeType)
        {
            Memories = new List<Memory>();
            CrimeType = crimeType;
            ImpactEvaluation = "Not Evaluated";
        }

        public void AddMemory(Memory memory)
        {
            Memories.Add(memory);
        }

        public void RunSimulation()
        {
            // Lógica de la simulación: evaluamos el impacto de la simulación aquí.
            if (CrimeType == "Violent")
            {
                ImpactEvaluation = "High impact on mental health, long-term effects.";
            }
            else if (CrimeType == "Theft")
            {
                ImpactEvaluation = "Moderate impact, short-term memory effects.";
            }
            else if (CrimeType == "Financial")
            {
                ImpactEvaluation = "Low impact, financial consequences considered.";
            }
            else if (CrimeType == "Hate")
            {
                ImpactEvaluation = "Psychological impact with social consequences.";
            }
            else
            {
                ImpactEvaluation = "Unspecified impact.";
            }

            // Aquí podrías hacer un análisis más detallado de los recuerdos y su impacto.
            foreach (var memory in Memories)
            {
                // A medida que la simulación avanza, puedes evaluar el impacto de cada recuerdo.
                // Ejemplo: podrías usar la intensidad y la duración para cambiar la evaluación de impacto.
                if (memory.Intensity == "High")
                {
                    ImpactEvaluation += " Severe emotional impact due to high-intensity memories.";
                }
            }
        }

        // Método para mostrar los resultados de la simulación con más detalles
        public string GetSimulationResult()
        {
            var result = $"Crime Type: {CrimeType}, Impact: {ImpactEvaluation}, Memories: {Memories.Count}\n";

            // Mostrar los detalles de los recuerdos involucrados en la simulación
            foreach (var memory in Memories)
            {
                result += $"\nMemory Description: {memory.Description}\n";
                result += $"Intensity: {memory.Intensity}, Duration: {memory.Duration}\n";
            }

            return result;
        }
    }
}

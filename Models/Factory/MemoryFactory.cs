// Models/Factory/MemoryFactory.cs
namespace Cognify.Models.Factory
{
    public abstract class MemoryFactory
    {
        // Método abstracto con parámetros para crear recuerdos
        public abstract Memory CreateMemory(string description, string intensity, string duration);
    }
}

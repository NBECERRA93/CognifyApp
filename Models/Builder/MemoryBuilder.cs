namespace Cognify.Models.Builder
{
    public class MemoryBuilder
    {
        private Memory _memory;

        public MemoryBuilder()
        {
            _memory = new Memory();
        }

        public MemoryBuilder SetDescription(string description)
        {
            _memory.Description = description;
            return this;
        }

        public MemoryBuilder SetIntensity(string intensity)
        {
            _memory.Intensity = intensity;
            return this;
        }

        public MemoryBuilder SetDuration(string duration)
        {
            _memory.Duration = duration;
            return this;
        }

        public Memory Build()
        {
            return _memory;
        }
    }
}

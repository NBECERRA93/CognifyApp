namespace Cognify.Models.Singleton
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        public string SimulationSetting { get; set; }

        private ConfigurationManager() { }

        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationManager();
                }
                return _instance;
            }
        }
    }
}

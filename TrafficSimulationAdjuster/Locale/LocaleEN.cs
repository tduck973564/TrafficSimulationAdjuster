//adapted from TreeController

namespace TrafficSimulationAdjuster.Locale
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleEN : IDictionarySource
    {
        private readonly TrafficSimulationAdjusterOptions m_Setting;
        public LocaleEN(TrafficSimulationAdjusterOptions options)
        {
            m_Setting = options;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Traffic Simulation Adjuster" },
            };

        }
        public void Unload()
        {
        }
    }
}
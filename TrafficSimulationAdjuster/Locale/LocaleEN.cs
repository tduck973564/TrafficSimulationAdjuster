//adapted from TreeController
namespace TrafficSimulationAdjuster.Locale
{
    using System.Collections.Generic;
    using Colossal;
    using O = TrafficSimulationAdjusterOptions;

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
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(O.TrafficReductionCoefficient)),
                    "Traffic reduction value"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(O.TrafficReductionCoefficient)),
                    "Amount of traffic reduction. 4 is the vanilla value. Going lower increases traffic in larger cities, with a hit to performance. Higher values do the opposite."
                },
            };
        }
        public void Unload()
        {
        }
    }
}
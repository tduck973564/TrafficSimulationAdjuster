//adapted from TreeController
namespace TrafficSimulationAdjuster.Locale
{
    using System.Collections.Generic;

    using Colossal;

    using O = TrafficSimulationAdjusterOptions;

    public class LocaleZHHANS : IDictionarySource
    {
        private readonly TrafficSimulationAdjusterOptions m_Setting;
        public LocaleZHHANS(TrafficSimulationAdjusterOptions options)
        {
            m_Setting = options;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "交通模拟调整" },
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(O.TrafficReductionCoefficient)),
                    "交通流量减少值"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(O.TrafficReductionCoefficient)),
                    "交通流量减少值，原版值为4。更低的值将会增加大型城市中的车流，可能带来更严重的性能问题。更高的值则相反。"
                },
            };
        }
        public void Unload()
        {
        }
    }
}
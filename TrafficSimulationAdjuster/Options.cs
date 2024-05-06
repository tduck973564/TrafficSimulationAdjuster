using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace TrafficSimulationAdjuster;

[FileLocation(nameof(TrafficSimulationAdjuster))]
public class TrafficSimulationAdjusterOptions : ModSetting
{
    public TrafficSimulationAdjusterOptions(IMod mod) : base(mod) { }

    [SettingsUISlider(min = 0, max = 10)] 
    [SettingsUISetter(typeof(TrafficSimulationAdjusterOptions), nameof(ApplySettings))]
    public int TrafficReductionCoefficient { get; set; }
    
    public sealed override void SetDefaults()
    {
        TrafficReductionCoefficient = 4;
    }
    
    public void ApplySettings(int value)
    {
        new PrefabPatcher().PatchEconomyParameters(value);
        TrafficReductionCoefficient = value;
    }
}
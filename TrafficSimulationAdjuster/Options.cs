using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace TrafficSimulationAdjuster;

[FileLocation(nameof(TrafficSimulationAdjuster))]
public class TrafficSimulationAdjusterOptions : ModSetting
{
    public TrafficSimulationAdjusterOptions(IMod mod)
        : base(mod)
    {
        if (TrafficReductionCoefficient == 0) SetDefaults();
    }

    [SettingsUISlider(min = 0, max = 10)] 
    [SettingsUISetter(typeof(ModSetting), nameof(ApplySettings))]
    public int TrafficReductionCoefficient { get; set; }
    
    public sealed override void SetDefaults()
    {
        TrafficReductionCoefficient = 4;
    }
    
    public void ApplySettings()
    {
        new PrefabPatcher().PatchEconomyParameters(TrafficReductionCoefficient);
    }
}
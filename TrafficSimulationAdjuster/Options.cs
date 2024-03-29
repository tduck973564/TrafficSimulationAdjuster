using Game.Modding;

namespace TrafficSimulationAdjuster;

// TODO
public class TrafficSimulationAdjusterOptions : ModSetting
{
    public TrafficSimulationAdjusterOptions(IMod mod)
        : base(mod)
    {
        SetDefaults();
    }

    public override void SetDefaults()
    {
    }
}
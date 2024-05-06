using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using TrafficSimulationAdjuster.Locale;

namespace TrafficSimulationAdjuster
{
    public class Mod : IMod
    {
        public static TrafficSimulationAdjusterOptions? Options { get; set; }
        public static ILog Log = LogManager.GetLogger($"{nameof(TrafficSimulationAdjuster)}.{nameof(Mod)}")
            .SetShowsErrorsInUI(false);
        
        public void OnLoad(UpdateSystem updateSystem)
        {
            Options = new(this);
            AssetDatabase.global.LoadSettings(nameof(TrafficSimulationAdjuster), Options, new TrafficSimulationAdjusterOptions(this));
            Options.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Options));
            GameManager.instance.localizationManager.AddSource("zh-HANS", new LocaleZHHANS(Options));
            
            Log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                Log.Info($"Current mod asset at {asset.path}");
            
            // Patch prefabs
            PrefabPatcher patcher = new PrefabPatcher();
            patcher.PatchEconomyParameters(Options.TrafficReductionCoefficient);
        }

        public void OnDispose()
        {
        }
    }
}
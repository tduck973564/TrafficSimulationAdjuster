using Game.Prefabs;
using Unity.Entities;

namespace TrafficSimulationAdjuster
{
    // Adapted from Infixo/CS2-RealPop
    internal class PrefabPatcher
    {
        private EntityManager m_EntityManager;
        private PrefabSystem m_PrefabSystem;

        internal PrefabPatcher()
        {
            m_PrefabSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<PrefabSystem>();
            m_EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }
        
        internal bool TryGetPrefab(string prefabType, string prefabName, out PrefabBase prefabBase, out Entity entity)
        {
            prefabBase = null;
            entity = default;
            PrefabID prefabID = new PrefabID(prefabType, prefabName);
            return m_PrefabSystem.TryGetPrefab(prefabID, out prefabBase) && m_PrefabSystem.TryGetEntity(prefabBase, out entity);
        }

        internal void PatchEconomyParameters(int trafficReduction)
        {
            if (TryGetPrefab(nameof(EconomyPrefab), "EconomyParameters", out PrefabBase prefabBase, out Entity entity) && m_PrefabSystem.TryGetComponentData<EconomyParameterData>(prefabBase, out EconomyParameterData comp))
            {
                comp.m_TrafficReduction = trafficReduction / 10_000f; // vanilla is 0.0004f
                m_PrefabSystem.AddComponentData(prefabBase, comp);
                Mod.Log.Info($"Patched {prefabBase.name} for TrafficReduction={comp.m_TrafficReduction}");
            }
        }
    }
}
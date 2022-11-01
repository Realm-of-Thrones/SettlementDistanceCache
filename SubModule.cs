using HarmonyLib;
using SandBox;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;

namespace SettlementDistanceCache
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            new Harmony("mod.bannerlord.SettlementDistanceCache").PatchAll();
            base.OnSubModuleLoad();
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
        }
        
        [HarmonyPatch(typeof(SettlementPositionScript), "SettlementsDistanceCacheFilePath", MethodType.Getter)]
        public static class SettlementPositionScriptSettlementsDistanceCacheFilePath
        {
            public static void Postfix(ref string __result) => __result = ModuleHelper.GetModuleFullPath("RF-MAP") + "/ModuleData/settlements_distance_cache.bin";
        }
    }
}

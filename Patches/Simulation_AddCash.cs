using BTD_Mod_Helper;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace ExampleMod.Patches
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.AddCash))]
    internal static class Simulation_AddCash
    {
        public static void Postfix(double __result)
        {
            ModHelper.Log<ExampleMod>(__result);
        }

        public static bool Prefix(double c, Simulation.CashType from, Simulation.CashSource source, bool cashDoubleable, Tower tower)
        {
            cashDoubleable = !cashDoubleable;

            c += 3100;

            if (tower != null && tower.towerModel.baseId == TowerType.BananaFarm)
            {
                return false;
            }

            return true;
        }
    }
}

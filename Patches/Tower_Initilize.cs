using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;

namespace ExampleMod.Patches
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))] // [HarmonyPatch("Tower", "Initialise")
    internal static class Tower_Initilize
    {
        [HarmonyPostfix]
        public static void Postfix(Tower __instance)
        {
            ModHelper.Log<ExampleMod>("Placed tower named: " + __instance.towerModel.name);

            if(__instance.towerModel.baseId == TowerType.DartMonkey)
            {
                __instance.UpdatedModel(Game.instance.model.GetTower(TowerType.MonkeyVillage));
            }
            if(__instance.towerModel.baseId == ModContent.TowerID<ExampleMonkey>())
            {
                ExampleMod.ExampleMonkeysPlaced++;
            }
        }
    }
}

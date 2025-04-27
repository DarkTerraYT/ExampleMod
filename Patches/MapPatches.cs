using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Track;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace ExampleMod.Patches
{
    //Saving
    [HarmonyPatch(typeof(Map), nameof(Map.GetSaveData))]
    public static class Map_GetSaveData
    {
        public static void Postfix(MapSaveDataModel mapData)
        {
            if(ExampleMod.ExampleMonkeysPlaced > 0)
            {
                mapData.metaData[ExampleMod.SaveDataKey] = JsonConvert.SerializeObject(ModContent.GetContent<ModTower>()[0]);
            }
        }
    }
    //Loading
    [HarmonyPatch(typeof(Map), nameof(Map.SetSaveData))]
    public static class Map_SetSaveData
    {
        public static void Postfix(MapSaveDataModel mapData)
        {
            if (mapData.metaData.TryGetValue(ExampleMod.SaveDataKey, out string json))
            {
                ExampleMod.ExampleMonkeysPlaced = JsonConvert.DeserializeObject<int>(json);
                ModHelper.Log<ExampleMod>($"Placed {ExampleMod.ExampleMonkeysPlaced} Example Monkey(s)");
            }
        }
    }
}

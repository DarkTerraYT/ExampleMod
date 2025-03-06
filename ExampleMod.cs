using MelonLoader;
using BTD_Mod_Helper;
using ExampleMod;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api;
using ExampleMod.UI.Custom;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Components;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2CppAssets.Scripts.Models;

[assembly: MelonInfo(typeof(ExampleMod.ExampleMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ExampleMod;

public class ExampleMod : BloonsTD6Mod
{
    public override void OnMatchStart()
    {
        ModdedMonkeys.CreateMenu(Game.instance.model.towers.ToList());
    }

    public override void OnGameModelLoaded(GameModel model)
    {
        foreach (var bloon in model.bloons)
        {
            if (bloon.baseId == bloon.name)
            {
               ExampleGameMenu.baseModels.Add(bloon);
            }
            else
            {
                if (!ExampleGameMenu.bloonVarients.TryAdd(bloon.baseId, [bloon]))
                {
                    ExampleGameMenu.bloonVarients[bloon.baseId].Add(bloon);
                }
            }
        }
    }

    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
    static class MainMenu_Open
    {
        public static void Postfix(MainMenu __instance)
        {
            ExampleGameMenuButton.CreateButton(__instance);
        }
    }

    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.ReOpen))]
    static class MainMenu_ReOpen
    {
        public static void Postfix(MainMenu __instance)
        {
            ExampleGameMenuButton.CreateButton(__instance);
        }
    }

    public override void OnMatchEnd()
    {
        ModdedMonkeys.instance.Close();
    }

    public override void OnApplicationStart()
    {
        ModHelper.Msg<ExampleMod>("ExampleMod loaded!");
    }

    public static readonly ModSettingCategory Category = new("Example Category")
    { 
        icon = "Cog1.png"
    };

    public static readonly ModSettingInt Damage = new(5)
    {
        requiresRestart = true,
        category = Category,
        description = "Description"
    };
    public static readonly ModSettingInt Range = new(10)
    {
        requiresRestart = true,
        category = Category,
        description = "Description"
    };
    public static readonly ModSettingInt Pierce = new(5)
    {
        requiresRestart = true,
        category = Category,
        description = "Description"
    };
    public static readonly ModSettingInt Cost = new(1040)
    {
        requiresRestart = true,
        category = Category,
        description = "Description"
    };

    public static readonly ModSettingDouble AttackSpeedMultiplier = new(0.5)
    {
        requiresRestart = true,
        category = Category,
        description = "What the attack speed is multiplied by"
    };

    public override void OnWeaponFire(Weapon weapon)
    {
        var tower = weapon.attack.tower;

        if(tower.towerModel.baseId == ModContent.TowerID<CustomModelTower>())
        {
            //tower.GetUnityDisplayNode().gameObject.GetComponent<Animator>().SetTrigger("Attack");
            tower.GetUnityDisplayNode().animationComponent.SetTrigger("Attack");
        }
    }
}

public static class Ext
{
    public static void EnableAutoSizing(this ModHelperText text)
    {
        text.Text.enableAutoSizing = true;
    }

    public static void EnableAutoSizing(this ModHelperText text, float fontSizeMax)
    {
        text.Text.enableAutoSizing = true;
        text.Text.fontSizeMax = fontSizeMax;
    }
}
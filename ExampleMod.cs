using MelonLoader;
using BTD_Mod_Helper;
using ExampleMod;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api;
using UnityEngine;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Rounds;

[assembly: MelonInfo(typeof(ExampleMod.ExampleMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ExampleMod;

public class ExampleMod : BloonsTD6Mod
{
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
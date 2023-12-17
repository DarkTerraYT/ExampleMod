using MelonLoader;
using BTD_Mod_Helper;
using ExampleMod;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppNinjaKiwi.NKMulti.IO;

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
    
}
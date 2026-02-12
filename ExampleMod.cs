global using BTD_Mod_Helper.Extensions;
using MelonLoader;
using BTD_Mod_Helper;
using ExampleMod;

[assembly: MelonInfo(typeof(ExampleMod.ExampleMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ExampleMod;

public class ExampleMod : BloonsTD6Mod
{
    
}
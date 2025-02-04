using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;

namespace ExampleMod.Bloons
{
    internal class ExampleBloon : ModBloon
    {
        public override string BaseBloon => BloonType.Green;

        public override string Icon => VanillaSprites.LeadBloonIcon;

        //public override IEnumerable<string> DamageStates => ["DamageStateName", "DamageStateName2"];

        public override void ModifyBaseBloonModel(Il2CppAssets.Scripts.Models.Bloons.BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.Lead, 2);

            bloonModel.maxHealth = 4;

            bloonModel.bloonProperties = Il2Cpp.BloonProperties.Lead;
        }
    }
}

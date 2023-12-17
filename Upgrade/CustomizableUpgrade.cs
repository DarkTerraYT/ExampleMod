using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using static ExampleMod.ExampleMod;

namespace ExampleMod.Upgrade
{
    internal class CustomizableUpgrade : ModUpgrade<ExampleMonkey>
    {
        public override int Path => MIDDLE; //You can use TOP, MIDDLE or BOTTOM

        public override int Tier => 3; // 1, 2, 3, 4 or 5

        public override int Cost => ExampleMod.Cost;

        public override string Description => "Customizable, Made for Episode 4";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon(); // You can change this is towerModel.GetAttackModel().weapons[0];
            var projectileModel = weaponModel.projectile;

            attackModel.range += Range;
            towerModel.range += Range;

            weaponModel.rate *= AttackSpeedMultiplier;

            projectileModel.pierce += Pierce;
            projectileModel.GetDamageModel().damage += Damage;
        }
    }
}

using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ExampleMod.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace ExampleMod
{
    public class ExampleMonkey : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.SuperMonkey; // "SuperMonkey" or "SuperMonkey-005" to set the base tower to legend of the night

        public override int Cost => 1050;

        public override ParagonMode ParagonMode => ParagonMode.Base555;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon(); // attackModel.weapons[0]
            var projectileModel = weaponModel.projectile;

            // Change Range
            towerModel.IncreaseRange(10); // increase towerModel range by 10 and all attack model ranges by 10

            /* Set the range to 20
            towerModel.range = 20;
            attackModel.range = 20;
            */

            // Attack speed (in seconds)
            weaponModel.rate /= 3; // 3x as fast

            // Damage + Pierce
            projectileModel.pierce = 3; // Can hit 4 bloons at once
            var damageModel = projectileModel.GetDamageModel();
            damageModel.damage += 2; // Increase the damage by 2

            // Displays
            towerModel.ApplyDisplay<ExampleMonkeyDisplay>();
            projectileModel.ApplyDisplay<ExampleProjectileDisplay>();
        }
    }
}

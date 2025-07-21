using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Upgrade
{
    // Paragon won't show without -555 upgrades.
    public class ExampleParagonUpgrade : ModParagonUpgrade<ExampleMonkey>
    {
        // How much the paragon upgrade costs on medium difficulty
        public override int Cost => 500000;

        // Apply upgrade here is the same as any ModUpgrade
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon(); // attackModel.weapons[0]
            var projectileModel = weaponModel.projectile;
            weaponModel.rate = 0;
            projectileModel.pierce = 25;
            projectileModel.GetDamageModel().damage = 999999;
            projectileModel.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}

using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ExampleMod;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeJacksonCompete.UpgradesOliver
{
    internal class ThornSwarm : ModUpgrade<ExampleMonkey>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => 250;

        public override string Description => "Shoots 8 thorns per shot instead of 5.";

        public override string Icon => VanillaSprites.ThornSwarmUpgradeIcon;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon();
            var projectileModel = weaponModel.projectile;

            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 25, null, false, false);

        }
    }
}

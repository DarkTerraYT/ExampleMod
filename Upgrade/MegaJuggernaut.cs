using BTD_Mod_Helper.Extensions;
using ExampleMod.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using PathsPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Upgrade
{
    internal class MegaJuggernaut : UPP<ExamplePathExtension> //UPP is a custom class that I added for sake of time, you can change it to UpgradePlusPlus<ExamplePathExtension>.
    {
        public override int Cost => 21000;

        public override int Tier => 6;

        public override string Description => "Mega Juggernaut Balls CRUSH all bloons in sight...";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var weaponModel = towerModel.GetWeapon();
            var projectileModel = weaponModel.projectile;
            var oldProj = projectileModel.Duplicate();
            var cpoefm = projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>();

            weaponModel.rate /= 2;
            projectileModel.GetDamageModel().damage += 5;
            cpoefm.projectile = oldProj;

            cpoefm.emission = new ArcEmissionModel("ArcEmissionModel", 10, 0, 360, null, false, false);

            projectileModel.ApplyDisplay<MegaJuggernautDisplay>();
        }
    }
}

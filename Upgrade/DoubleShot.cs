using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using PathsPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Upgrade
{
    internal class DoubleShot : UPP<ExampleFourthPath>
    {
        public override int Cost => 550;

        public override int Tier => 1;

        public override string Description => "Dart Monkey now shoots two darts (If you have triple shot it'll shoot 5).";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var weaponModel = towerModel.GetWeapon();

            if (towerModel.tiers[1] >= 3)
            {
                weaponModel.SetEmission(new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false));
            }
            else
            {
                weaponModel.SetEmission(new ArcEmissionModel("ArcEmissionModel_", 2, 0, 30, null, false, false));
            }
        }
    }
}

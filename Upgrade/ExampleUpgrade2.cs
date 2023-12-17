using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace ExampleMod.Upgrade
{
    internal class ExampleUpgrade2 : ModUpgrade<ExampleMonkey>
    {
        public override int Path => MIDDLE; //You can use TOP, MIDDLE or BOTTOM

        public override int Tier => 2; // 1, 2, 3, 4 or 5

        public override int Cost => 965;

        public override string Description => "Adds Multishot + Cool Stuff";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var weaponModel = towerModel.GetWeapon();

            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 25, null, false, false);

            // Behaviors

            // weaponModel.projectile.AddBehavior(new TrackTargetModel("TrackTargetModel_", 80f, true, true, 360f, false, 1f, false, false));
            weaponModel.projectile.AddBehavior(Game.instance.model.GetTower("WizardMonkey", 2).GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate());
            weaponModel.projectile.AddBehavior(new CashModel("CashModel_", 5, 5, 0, 0, false, false, false, false));
            // weaponModel.projectile.AddBehavior(Game.instance.model.GetTower("BananaFarm").GetWeapon().projectile.GetBehavior<CashModel>().Duplicate());

            weaponModel.projectile.AddBehavior<CreateProjectileOnExhaustFractionModel>(new("CreateProjectileOnExhaustFractionModel_", weaponModel.projectile.Duplicate(), new ArcEmissionModel("ArcEmissionModel_", 2, 0, 45, null, false, false), 0.5f, 0.33333f, false, false, false));
            /*
            var airburstModel = Game.instance.model.GetTower("DartMonkey", 5).GetWeapon().projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate());
            ariburstModel.projectile = weaponModel.projectile.Duplicate();
            weaponModel.projectile.AddBehavior(airbustModel);
            */

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false); // Camo
            weaponModel.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.Frozen | Il2Cpp.BloonProperties.White; // Makes it so that the tower can pop everything but frozen and white
        }
    }
}

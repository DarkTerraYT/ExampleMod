using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace ExampleMod.Upgrade
{
    internal class ExampleUpgrade : ModUpgrade<ExampleMonkey>
    {
        public override int Path => MIDDLE; //You can use TOP, MIDDLE or BOTTOM

        public override int Tier => 1; // 1, 2, 3, 4 or 5

        public override int Cost => 670;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon(); // You can change this is towerModel.GetAttackModel().weapons[0];
            var projectileModel = weaponModel.projectile;

            // Adding a new Weapon
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("EngineerMonkey-002").GetWeapon().Duplicate());

            Il2CppReferenceArray<Model> models = new(0);

            models.AddTo(new TurboModel("TurboModel_", 10f, 0.5f, null, 1, 0.25f, true));

            var ability = new AbilityModel("exampleAbility", "Example Ability", "An Example Ability", 0, 0, GetSpriteReference(Icon), 25f, models, false, false, "", 0f, 0, 999999, false, false);

            towerModel.AddBehavior(ability);

            // range
            towerModel.range += 25;
            attackModel.range += 25;

            // attack speed
            weaponModel.rate *= 0.33f;

            // damage + pierce
            projectileModel.pierce += 10;
            projectileModel.GetDamageModel().damage += 4;
        }
    }
}

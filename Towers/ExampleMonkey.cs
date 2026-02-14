using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace ExampleMod.Towers;

public class ExampleMonkey : ModTower
{
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel(); // The first attack of the tower
        var weapon = attackModel.weapons[0]!; // towerModel.GetWeapon(): The first weapon the tower has
        var projectile = weapon.projectile; // The projectile the tower shoots

        weapon.rate = 0.33f; // Attack speed in seconds, add an f at the end if non-integer number
        weapon.SetEmission(new ArcEmissionModel("Emission", 3, 0f, 45f, null, false, false)); // Makes the tower shoot 3 darts in a 45 degree spread

        var damageModel = projectile.GetDescendant<DamageModel>(); // You can do projectile.GetDamageModel(), but it will error if it is not directly attached to the projectile
        damageModel.damage++; // 1 -> 2, ++ increments by 1, -- decrements by 1
        damageModel.immuneBloonProperties |= BloonProperties.Black | BloonProperties.White; // |= will make it also not able to hit that type, using just = will override it, using vertical bars after the equals will do all of those.
                                                                                            // For example, this can't pop black bloons, white bloons, frozen bloons, or lead bloons
        projectile.pierce = 10; // Can hit 11 bloons
        projectile.AddBehavior(new SlowModel("SlowModel_low", 0.9f, 5, "Slow:ExampleMonkey_low", 999999,
            "", true, false, null, false, false, false, 100)); // Makes bloons 10% slower for 5 seconds
        
        projectile.UpdateCollisionPassList();
        
        projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1.5f, 0, false, true)); // Does 1.5x more damage to Moab Class Bloons, For a Moab specifically, do just "Moab" as the tag.
        projectile.hasDamageModifiers = true;
        
        towerModel.IncreaseRange(10); // Increase towerModel.range by 10, and the range for each attackModel by 10 (towerModel.GetAttackModels().ForEach(attackModel => attackModel.range += increase));
        
        towerModel.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false); // Set this to true if you don't want it to see camo
    }

    public override TowerSet TowerSet => TowerSet.Primary;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 815; // 815 cash in medium mode

    public override string Icon => Portrait; // Portrait is ClassName-Portrait (.png)

    public override string Description => "This is an Example Monkey, woohoo!"; // The text the shown under the name of the tower in the upgrades menu.
    public override string DisplayName => "Example Monkey"; // If the class is called MOABMonkey for example, it'll show as M O A B Monkey in game. If you have MoabMonkey, it'll show as Moab Monkey in game. You'd use this to fix it and have it shown as "MOAB Monkey". By default, this is Name.Spaced();
} 
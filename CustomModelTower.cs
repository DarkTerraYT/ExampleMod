using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExampleMod
{
    internal class CustomModelTower : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.DartMonkey;

        public override string Description => "A tower with a custom model & animation. Functionally a dart monkey.";

        public override int Cost => 200;

        public override string Portrait => Icon;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
        }
    }

    internal class CustomModelDisplay : ModTowerCustomDisplay<CustomModelTower>
    {
        public override string AssetBundleName => "examplemod";

        public override string PrefabName => "CustomTower";

        public override bool UseForTower(params int[] tiers)
        {
            return tiers.Sum() >= 0;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach(var meshRenderer in node.GetMeshRenderers())
            {
                if (!meshRenderer.name.Contains("Cylinder.003"))
                {
                    meshRenderer.ApplyOutlineShader();
                }

                meshRenderer.SetOutlineColor(Color.cyan);
            }
        }
    }
}

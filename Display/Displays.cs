using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ExampleMod.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExampleMod.Display
{
    internal class ExampleMonkeyDisplay : ModDisplay
    {
        public override string BaseDisplay => GetDisplay("SuperMonkey");

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            // Set2DTexture(node, "ExampleMonkey2dDisplay"); //Change "ExampleMonkey2dDisplay" With the name of your texture
            
            for (int i = 0; i < node.GetMeshRenderers().Count; i++)
            {
                // node.SaveMeshTexture(i); // Saves the mesh texture to %APPDATA%\..\LocalLow\NinjaKiwi\BloonsTD6\
                SetMeshTexture(node, "ExampleMonkeyDisplay" + i, i);
            }
        }
    }
    internal class ExampleProjectileDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "ExampleProjectileDisplay"); //Change "ExampleProjectileDisplay" With the name of your texture
        }
    }

    internal class ExampleBloonDisplay : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Lead);

        public override float Scale => 2;
    }

    internal class ExampleBloonDamage1Display : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Lead);

        public override float Scale => 1.75f;

        public override int Damage => 1;
    }

    internal class ExampleBloonDamage2Display : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Lead);

        public override float Scale => 1.5f;

        public override int Damage => 2;
    }

    internal class ExampleBloonDamage3Display : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Lead);

        public override float Scale => 1.25f;

        public override int Damage => 3;
    }

    internal class MegaJuggernautDisplay : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartMonkey-500").GetWeapon().projectile.display.GUID;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            for(int i = 0; i < node.GetMeshRenderers().Count; i++)
            {
                SetMeshTexture(node, "MegaJuggernautDiffuse", i);
                SetMeshOutlineColor(node, Color.blue);
            }
        }
    }
}

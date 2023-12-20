using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

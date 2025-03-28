using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using ExampleMod.Bloons;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Display
{
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

    public class StarMoabDisplay : ModBloonDisplay<StarMoab>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Moab);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach(var renderer in node.GetMeshRenderers())
            {
                renderer.SetMainTexture(GetTexture("StarMoabDamage0"));
            }
        }
    }

    public class StarMoabDisplay1 : ModBloonDisplay<StarMoab>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Moab);

        public override int Damage => 1;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach (var renderer in node.GetMeshRenderers())
            {
                renderer.SetMainTexture(GetTexture("StarMoabDamage1"));
            }
        }
    }

    public class StarMoabDisplay2 : ModBloonDisplay<StarMoab>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Moab);

        public override int Damage => 2;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach (var renderer in node.GetMeshRenderers())
            {
                renderer.SetMainTexture(GetTexture("StarMoabDamage2"));
            }
        }
    }

    public class StarMoabDisplay3 : ModBloonDisplay<StarMoab>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Moab);

        public override int Damage => 3;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach (var renderer in node.GetMeshRenderers())
            {
                renderer.SetMainTexture(GetTexture("StarMoabDamage3"));
            }
        }
    }

    public class StarMoabDisplay4 : ModBloonDisplay<StarMoab>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Moab);

        public override int Damage => 4;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach (var renderer in node.GetMeshRenderers())
            {
                renderer.SetMainTexture(GetTexture("StarMoabDamage4"));
            }
        }
    }
}

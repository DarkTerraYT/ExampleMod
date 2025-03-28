using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using ExampleMod.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod
{
    public class Moab : ModVanillaBloon
    {
        public override string BloonId => BloonType.Moab;

        public override void Apply(Il2CppAssets.Scripts.Models.Bloons.BloonModel model)
        {
            model.damageDisplayStates[0].displayPath = new(GetDisplayGUID<StarMoabDisplay1>());
            model.damageDisplayStates[1].displayPath = new(GetDisplayGUID<StarMoabDisplay2>());
            model.damageDisplayStates[2].displayPath = new(GetDisplayGUID<StarMoabDisplay3>());
            model.damageDisplayStates[3].displayPath = new(GetDisplayGUID<StarMoabDisplay4>());
            model.ApplyDisplay<StarMoabDisplay>();
        }
    }
}

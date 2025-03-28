using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Bloons
{
    public class StarMoab : ModBloon
    {
        public override string BaseBloon => BloonType.sMoab;

        public override string Icon => Name + "Icon";

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2.5f;

            bloonModel.isMoab = true;
            /*bloonModel.isCamo = true;
            bloonModel.isBoss = true;
            bloonModel.isGrow = true;*/
        }
    }
}

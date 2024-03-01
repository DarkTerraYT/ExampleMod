using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using ExampleMod.Bloons;
using Il2CppAssets.Scripts.Models.Rounds;

namespace ExampleMod
{
    internal class ExampleRoundset : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;

        public override int DefinedRounds => 15;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            switch (round)
            {
                case 0:
                    roundModel.AddBloonGroup<ExampleBloon>(5, 300, 360);
                    break;

                case 3:
                    roundModel.RemoveBloonGroup(BloonType.Blue);
                    roundModel.AddBloonGroup<ExampleBloon>(6, 240, 300);
                    break;
                case 7:
                    roundModel.AddBloonGroup<ExampleBloon>(3, 60, 180);
                    break;
                case 14:
                    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup<ExampleBloon>(15, 0, 600);
                    break;
            }
        }
    }
}

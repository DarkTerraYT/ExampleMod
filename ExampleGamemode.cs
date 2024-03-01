using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Difficulty;

namespace ExampleMod
{
    internal class ExampleGamemode : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.Easy;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<ExampleRoundset>();
        }
    }
}

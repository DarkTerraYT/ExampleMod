using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace ExampleMod.UI.Custom
{
    public static class ExampleGameMenuButton
    {
        public static void CreateButton(MainMenu menu)
        {
            var buttonToCopy = menu.transform.FindChild("TrophyStore");

            var newBtn = buttonToCopy.gameObject.Duplicate();
            newBtn.transform.parent = buttonToCopy.parent;
            newBtn.transform.localScale /= 2.5f;
            newBtn.name = "ExampleButton";
            var matchLocalPosition = newBtn.AddComponent<MatchLocalPosition>();
            matchLocalPosition.transformToCopy = buttonToCopy;
            matchLocalPosition.offset = new(0, -340, 0);

            newBtn.GetComponentInChildren<Image>().SetSprite(ModContent.GetSpriteReference<ExampleMod>("BloonMenuBtn"));
            newBtn.GetComponentInChildren<Button>().SetOnClick(new(() => ModGameMenu.Open<ExampleGameMenu>()));
        }
    }
}

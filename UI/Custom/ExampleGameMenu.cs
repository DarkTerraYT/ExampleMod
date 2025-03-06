using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem.Runtime.InteropServices;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleMod.UI.Custom
{
    public class ExampleGameMenu : ModGameMenu<SettingsScreen>
    {
        ModHelperPanel mainPanel;

        RectTransform rect;

        internal static Dictionary<string, List<BloonModel>> bloonVarients = [];
        internal static List<BloonModel> baseModels = [];

        public override bool OnMenuOpened(Il2CppSystem.Object data)
        {
            CommonForegroundHeader.SetText("Ye Olde Bloon Menu");

            GameMenu.transform.DestroyAllChildren();

            rect= GameMenu.transform.Cast<RectTransform>();

            mainPanel = rect.gameObject.AddModHelperPanel(new("BloonMenu", 3200, 1800), VanillaSprites.MainBGPanelBlue);

            MelonCoroutines.Start(CreateMenu());

            return true;
        }

        public IEnumerator CreateMenu()
        {
            var scrollPanel = mainPanel.AddScrollPanel(new("Content", 0, -50, 3000, 1700), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanel, 50, 50);
            scrollPanel.ScrollContent.RemoveComponent<VerticalLayoutGroup>();
            yield return null;
            var layoutGroup = scrollPanel.ScrollContent.AddComponent<GridLayoutGroup>();
            layoutGroup.cellSize = new(200, 300);

            foreach(var bloon in Game.instance.model.bloons.OrderBy(bl => bl.danger))
            {
                scrollPanel.AddScrollContent(BloonProfile(bloon));
                yield return null;
            }

            yield return null;
        }

        public ModHelperPanel BloonProfile(BloonModel bloon)
        {
            ModHelperPanel panel = ModHelperPanel.Create(new(bloon.name), VanillaSprites.MainBGPanelBlue);

            var icon = panel.AddImage(new("Icon", 200), bloon.icon.GetGUID());

            var name = panel.AddText(new("Name", 0, 100, 200, 100), bloon.name.GetBtd6Localization());
            name.EnableAutoSizing();

            var health = panel.AddText(new("Health", 0, -100, 200, 100), bloon.maxHealth.ToString());

            return panel;
        }

        //public void CreateBloonProfile();
    }
}

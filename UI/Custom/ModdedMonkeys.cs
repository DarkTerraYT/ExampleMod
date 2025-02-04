using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleMod.UI.Custom
{
    [RegisterTypeInIl2Cpp]
    internal class ModdedMonkeys : MonoBehaviour
    {
        public static ModdedMonkeys instance;

        static RectTransform mapRect;

        public void Close()
        {
            if(gameObject)
            {
                gameObject.Destroy();
            }
        }

        public static void CreateMenu(List<TowerModel> towers)
        {
            mapRect = InGame.instance.mapRect;

            var buttonPanel = mapRect.gameObject.AddModHelperPanel(new("ModdedMonkeys", mapRect.rect.right - 150, mapRect.rect.bottom - 350, 250));

            instance = buttonPanel.AddComponent<ModdedMonkeys>();

            var button = buttonPanel.AddButton(new("ModdedMonkeysBtn", BTD_Mod_Helper.Api.Components.InfoPreset.FillParent), ModContent.GetTextureGUID<ExampleMod>("ModdedMonkeysMenu"), new Action(() =>
            {
                instance.OpenMenu(towers.FindAll(tower => tower.GetModTower() != null && tower.name == tower.baseId));
            }));
        }

        public void OpenMenu(List<TowerModel> moddedTowers)
        {
            var towersPanel = mapRect.gameObject.AddModHelperPanel(new("ModdedMonkeysMenu", mapRect.rect.center.x, mapRect.rect.center.y, 780, 1560), VanillaSprites.MainBGPanelBlue);

            var title = towersPanel.AddText(new("Title", 0, 630, 750, 200), "Modded Monkeys");
            title.EnableAutoSizing();
            title.Text.fontSizeMax += 10;

            var backBtn = towersPanel.AddButton(new("BackBtn", towersPanel.RectTransform.rect.right, towersPanel.RectTransform.rect.bottom, 175), VanillaSprites.BackBtn, new Action(towersPanel.gameObject.Destroy));

            var towersScroll = towersPanel.AddScrollPanel(new("Content", 0, -130, 680, 1300), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanelRound, 50);

            foreach(var tower in moddedTowers)
            {
                towersScroll.AddScrollContent(ModTowerPanel(tower));
            }
        }

        string[] backgroundGuid(TowerSet set)
        {
            switch (set)
            {
                case TowerSet.Primary:
                    return [VanillaSprites.TowerContainerPrimary, VanillaSprites.PortraitContainerPrimary];
                case TowerSet.Military:
                    return [VanillaSprites.TowerContainerMilitary, VanillaSprites.PortraitContainerMilitary];
                case TowerSet.Magic:
                    return [VanillaSprites.TowerContainerMagic, VanillaSprites.PortraitContainerMagic];
                case TowerSet.Support:
                    return [VanillaSprites.TowerContainerSupport, VanillaSprites.PortraitContainerSupport];
                case TowerSet.Hero:
                    return [VanillaSprites.TowerContainerHero, VanillaSprites.PortraitContainerHero];
            }

            return [VanillaSprites.TowerContainerPrimary, VanillaSprites.PortraitContainerPrimary];
        }

        ModHelperPanel ModTowerPanel(TowerModel moddedTower)
        {
            ModTower modTower = moddedTower.GetModTower();

            var panel = ModHelperPanel.Create(new("Tower_" + moddedTower.name, 600, 730), backgroundGuid(moddedTower.towerSet)[0]);

            var portrait = panel.AddImage(new("Portrait", 500), moddedTower.portrait.AssetGUID);

            var name = panel.AddText(new("Name", 0, 315, 550, 100), modTower.DisplayName);
            name.EnableAutoSizing();

            var modName = panel.AddText(new("Mod", 0, -315, 550, 100), modTower.mod.GetModName().GetBtd6Localization());
            modName.EnableAutoSizing();

            return panel;
        }
    }
}

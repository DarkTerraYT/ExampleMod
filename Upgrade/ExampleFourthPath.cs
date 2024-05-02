using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers;
using PathsPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Upgrade
{
    internal class ExampleFourthPath : PathPlusPlus
    {
        public override string Tower => TowerType.DartMonkey; // TowerID<ExampleMonkey>();
    }
}

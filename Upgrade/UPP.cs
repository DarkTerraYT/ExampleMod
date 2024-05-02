using PathsPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Upgrade
{
    abstract class UPP<T> : UpgradePlusPlus<T> where T : PathPlusPlus
    {
        public override string Icon => Name + "-Icon";

        public override string? Portrait => Name + "-Portrait";
    }
}

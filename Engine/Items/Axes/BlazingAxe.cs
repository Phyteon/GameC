using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Axes
{
    [Serializable]
    class BlazingAxe : Item

    {
        public BlazingAxe() : base ("item1153")
        {
            PublicTip = "15% reduction of physical damage";
            PublicName = "Blazing Axe";
            GoldValue = 80;
            StrMod = 20;

        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Physical(pack.DamageType))
            {
                pack.HealthDmg = 85 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }

}

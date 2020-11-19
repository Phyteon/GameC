using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Amulet
{
    [Serializable]
    class AntiPoisonAmulet :Item
    {
        public AntiPoisonAmulet() : base("item1080")
        {
            PublicName = "AntiPoisonAmulet";
            PublicTip = "extra 30% reduction of poison damage";
            GoldValue = 40;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Poison)
            {
                pack.HealthDmg = 70 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}

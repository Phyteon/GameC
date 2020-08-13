using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class WaterStone : Item
    {
        private int waterStoneBonus;
        public WaterStone() : base("item0851")
        {
            PublicName = "Water Stone";
            GoldValue = 30;
            ArMod = 10;
			PublicTip = "convert received damage into water damage bonus";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.water)
            {
                pack.HealthDmg += waterStoneBonus;
            }

            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            waterStoneBonus += 50 * pack.HealthDmg / 100;
            return pack;
        }
    }
}

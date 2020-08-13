using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class AirStone : Item
    {
        private int airStoneBonus;
        public AirStone() : base("item0855")
        {
            PublicName = "Air Stone";
            GoldValue = 30;
            ArMod = 10;
			PublicTip = "convert received damage into air damage bonus";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.air)
            {
                pack.HealthDmg += airStoneBonus;
            }

            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            airStoneBonus += 50 * pack.HealthDmg / 100;
            return pack;
        }
    }
}

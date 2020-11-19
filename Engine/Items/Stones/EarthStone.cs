using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class EarthStone : Item
    {
        private int earthStoneBonus;
        public EarthStone() : base("item0854")
        {
            PublicName = "Earth Stone";
            GoldValue = 30;
            ArMod = 10;
			PublicTip = "convert received damage into earth damage bonus";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Earth)
            {
                pack.HealthDmg +=  earthStoneBonus;
            }

            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            earthStoneBonus += 50 * pack.HealthDmg / 100;
            return pack;
        }
    }
}

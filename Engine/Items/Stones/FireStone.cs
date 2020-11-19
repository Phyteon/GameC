using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class FireStone : Item
    {
        private int fireStoneBonus;
        public FireStone() : base("item0850")
        {
            PublicName = "Fire Stone";
            GoldValue = 30;
            ArMod = 10;
			PublicTip = "convert received damage into fire damage bonus";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Fire)
            {
                pack.HealthDmg += fireStoneBonus;
            }

            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            fireStoneBonus += 50 * pack.HealthDmg / 100;
            return pack;
        }
    }
}

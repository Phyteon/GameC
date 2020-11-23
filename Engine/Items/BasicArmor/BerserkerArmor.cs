using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class BerserkerArmor : Item
    {
        // special passive: receive physical damage bonus after losing health

        private int berserkerBonus;
        public BerserkerArmor() : base("item0007")
        {
            PublicName = "BerserkerArmor";
            PublicTip = "when you lose X health, receive a X/4 percentage bonus to physical damage you deal in this battle";
            GoldValue = 40;
            ArMod = 20;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Crush)
            {
                pack.HealthDmg = (100 + berserkerBonus / 4) * pack.HealthDmg / 100;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            berserkerBonus += pack.HealthDmg;
            return pack;
        }
    }
}

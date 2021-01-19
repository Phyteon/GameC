using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Swords
{
    [Serializable]
    class FierySword : Sword
    {
        private int bonus;
        public FierySword() : base("item1320")
        {
            StrMod = 20;
            PrMod = 10;
            GoldValue = 100;
            PublicName = "Fiery Sword";
            PublicTip = "absorb 40% of received fire damage and strengthen cut and crush attacks by about 50% of absorbed damage";
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Fire)
            {
                pack.HealthDmg = 60 * pack.HealthDmg / 100;
                bonus = pack.HealthDmg / 5;
            }
            return pack;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Crush)
            {
                pack.StrengthDmg = pack.StrengthDmg + bonus;
            }
            return pack;
        }

    }
}

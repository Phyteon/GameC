using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Axes
{
    [Serializable]
    class DiamondAxe : Axe
    {
        private int diamondBonus;
        public DiamondAxe() : base ("item1152")
        {
            PublicName = "Diamond Axe";
            PublicTip = "when you lose X strength, receive a X percentage bonus to physical damage you deal in this battle";
            GoldValue = 40;
            ArMod = 20;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Crush)
            {
                pack.HealthDmg = (100 + diamondBonus ) * pack.HealthDmg / 100;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            diamondBonus += pack.StrengthDmg;
            return pack;
        }
    }
}

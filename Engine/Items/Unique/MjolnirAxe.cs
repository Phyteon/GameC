using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.MyItems
{
    // deal more dmg when you have more than 5 items
    [Serializable]
    class MjolnirAxe : Axe
    {
        private int mjolnirBonus;
        public MjolnirAxe() : base("item1301")
        {
            StrMod = 40;
            GoldValue = 75;
            PublicName = "MjolnirAxe";
            PublicTip = "sacrifice is part of the plan!";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Cut)
            {
                pack.HealthDmg = (100 + mjolnirBonus) / 100 * pack.HealthDmg;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (otherItems.Count() >= 5)
                mjolnirBonus += pack.HealthDmg;
            return pack;
        }
    }
}

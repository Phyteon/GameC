using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shields
{
    [Serializable]
    class SteelShield : Item
    {
        public SteelShield() : base("item1224")
        {
            PublicName = "Steel Shield";
            PublicTip = "When you lose X health, receive a X/4 percentage bonus to physical damage you deal in the battle.";
            GoldValue = 60; 
            ArMod = 20;
        }
        private int shieldBonus;
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        { 
            if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Crush)
            {
                pack.HealthDmg = (100 + shieldBonus/ 4) * pack.HealthDmg / 100;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            shieldBonus += pack.HealthDmg;
            return pack;
        }
    }
}

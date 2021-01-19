using System;
using System.Collections.Generic;

namespace Game.Engine.Items.EnhancedArmor
{
    // special passive effect: reduce poison damage by half
    
    [Serializable]
    public class AntiPoisonArmor : Item
    {
        public AntiPoisonArmor() : base("item1242")
        {
            PublicName = "AntiPoisonArmor";
            PublicTip = "Reduce poison damage by half";
            GoldValue = 75;
            ArMod = 40;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Poison)
            {
                pack.HealthDmg = pack.HealthDmg / 2;
            }
            return pack;
        }
    }
}
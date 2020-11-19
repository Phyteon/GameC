using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class AntiMagicArmor : Item
    {
        // extra reduction of magic damage
        public AntiMagicArmor() : base("item0006")
        {
            PublicName = "AntiMagicArmor";
            PublicTip = "extra 30% reduction of magic damage";
            GoldValue = 40;
            ArMod = 20;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Fire || pack.DamageType == DmgType.Water || pack.DamageType == DmgType.Air || pack.DamageType == DmgType.Earth)
            {
                pack.HealthDmg = 70 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}

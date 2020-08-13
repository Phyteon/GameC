using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class AntiMagicHealthStone : Item
    {
        // reduction of magic damage
        public AntiMagicHealthStone() : base("item0853")
        {
            PublicName = "Anti Magic Health Stone";
            PublicTip = "40% reduction of magic damage";
            GoldValue = 100;
            ArMod = 30;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.fire || pack.DamageType == DmgType.water || pack.DamageType == DmgType.air || pack.DamageType == DmgType.earth)
            {
                pack.HealthDmg = 40 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}

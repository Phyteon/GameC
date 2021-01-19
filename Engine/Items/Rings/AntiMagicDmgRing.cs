using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Ring
{
    [Serializable]
    class AntiMagicDmgRing : Item
    {
        public AntiMagicDmgRing() : base("item1113")
        {
            PublicName = "AntiMagicDmgRing";
            PublicTip = "30% reduction of magic damage, but 10% increase of physical damage";
            GoldValue = 30;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Magic(pack.DamageType))
            {
                pack.HealthDmg = 70 * pack.HealthDmg / 100;
            }
            if (DmgTest.Physical(pack.DamageType))
            {
                pack.HealthDmg = 110 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}
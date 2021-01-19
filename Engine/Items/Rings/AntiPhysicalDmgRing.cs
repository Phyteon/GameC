using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Ring
{
    [Serializable]
    class AntiPhysicalDmgRing : Item
    {
        public AntiPhysicalDmgRing() : base("item1104")
        {
            PublicName = "AntiPhysicalDmgRing";
            PublicTip = "30% reduction of physical damage, but 10% increase of magic damage";
            GoldValue = 30;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Physical(pack.DamageType))
            {
                pack.HealthDmg = 70 * pack.HealthDmg / 100;
            }
            if (DmgTest.Magic(pack.DamageType))
            {
                pack.HealthDmg = 110 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}
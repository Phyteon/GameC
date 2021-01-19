using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicAmulet
{
    [Serializable]
    class MgcAmulet : Item
    {
        public MgcAmulet() : base("item1103")
        {
            PublicName = "MgcAmulet";
            PublicTip = "5% increase of magic type damages you deal in this battle";
            GoldValue = 30;
            MgcMod = 10;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Magic(pack.DamageType))
            {
                pack.HealthDmg = 105 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}

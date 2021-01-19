using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.MyItems
{
    [Serializable]
    class BloodyArmor : Item
    {
        //receive health bonus after dealing dmg

        private int bloodbonus = 1;
        public BloodyArmor() : base("item1303")
        {
            PublicName = "BloodyArmor";
            PublicTip = "drink their blood!";
            GoldValue = 100;
            HpMod = 10;
            ArMod = 10;
            StaMod = 20;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Magic(pack.DamageType) || DmgTest.Physical(pack.DamageType))
            {
                HpMod += bloodbonus;
                bloodbonus += 1;
            }
            return pack;
        }
    }
}

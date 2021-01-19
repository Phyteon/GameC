using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.MyItems
{
    [Serializable]
    class BigBertha : Sword
    {
        private int kingbonus = 1;
        public BigBertha() : base("item1307")
        {
            PublicName = "BigBertha";
            PublicTip = "you know the rules and so do I.";
            GoldValue = 120;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Physical(pack.DamageType))
            {
                HpMod  += kingbonus;
                StrMod += kingbonus;
                ArMod  += kingbonus;
                PrMod  += kingbonus;
                StaMod += kingbonus;
            }
            return pack;
        }
    }
}
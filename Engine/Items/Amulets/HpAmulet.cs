using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicAmulet
{
    [Serializable]
    class HpAmulet : Item
    {
        //basic Hp amulet, gives extra 15 health points
        public HpAmulet() : base("item1100")
        {
            PublicName = "HpAmulet";
            GoldValue = 20;
            HpMod = 25;
        }
    }
}

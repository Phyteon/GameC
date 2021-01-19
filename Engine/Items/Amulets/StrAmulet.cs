using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicAmulet
{
    [Serializable]
    class StrAmulet : Item
    {
        //basic strength amulet, gives extra 5 strength points
        public StrAmulet() : base("item1101")
        {
            PublicName = "StrAmulet";
            GoldValue = 20;
            StrMod = 10;
        }
    }
}

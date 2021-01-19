using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class TreantProtectionAmulet : Item
    {
        public TreantProtectionAmulet() : base("item0420")
        {
            PublicName = "TreantProtectionAmulet";
            PublicTip = "Might be helpful against treants. ";
            GoldValue = 25;
        }

    }
}
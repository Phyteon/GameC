using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OldTravelerPotion : Potion
    {
        public OldTravelerPotion() : base("item1314")
        {
            StrMod = 5;
            PrMod = 5;
            MgcMod = 5;
            ArMod = 5;
            HpMod = 5;
            StaMod = 5;
            GoldValue = 25;
            PublicName = "OldTraveler Potion";
        }
    }
}


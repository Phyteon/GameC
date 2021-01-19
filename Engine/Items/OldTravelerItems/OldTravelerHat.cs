using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OldTravelerHat : Hat
    {
        public OldTravelerHat() : base("item1315")
        {
            StrMod = 3;
            PrMod = 3;
            MgcMod = 3;
            ArMod = 3;
            HpMod = 3;
            StaMod = 3;
            GoldValue = 22;
            PublicName = "OldTraveler Hat";
        }
    }
}


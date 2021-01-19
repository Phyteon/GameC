using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OldTravelerSpear : Spear
    {
        public OldTravelerSpear() : base("item1318")
        {
            PrMod = 8;
            GoldValue = 15;
            PublicName = "OldTraveler Spear";
        }
    }
}
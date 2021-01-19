using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OldTravelerAxe : Axe
    {
        public OldTravelerAxe() : base("item1319")
        {
            StrMod = 13;
            GoldValue = 15;
            PublicName = "OldTraveler Axe";
        }
    }
}

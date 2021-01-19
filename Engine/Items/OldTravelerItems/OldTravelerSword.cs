using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OldTravelerSword : Sword
    {
        public OldTravelerSword() : base("item1317")
        {
            StrMod = 8;
            PrMod = 5;
            GoldValue = 15;
            PublicName = "OldTraveler Sword";
        }
    }
}

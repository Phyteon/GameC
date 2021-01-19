using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OrbOfGods : Item
    {
        public OrbOfGods() : base("item0421")
        {
            HpMod = 50;
            StrMod = 30;
            ArMod = 30;
            PrMod = 30;
            MgcMod = 30;
            StaMod = 50;
            GoldValue = 750;
            PublicName = "Orb of Gods";
            PublicTip = "Enhances all statistics. Exceptionally valuable";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnnItems
{
    [Serializable]
    class AnnPoison : Item
    {
        public AnnPoison() : base("item1323")
        {
            StrMod = 15;
            GoldValue = 30;
            PublicName = "Ann's Poison";
        }

    }
}

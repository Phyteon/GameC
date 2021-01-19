using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnimalItems
{
    class BearHat : Item
    {
        public BearHat() : base("item0125") // zmienić wygląd
        {
            HpMod = 50;
            ArMod = 50;
            GoldValue = 10;
            PublicName = "Bear hat";
        }
    }
}

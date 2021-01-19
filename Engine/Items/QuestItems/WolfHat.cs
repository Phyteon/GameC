using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnimalItems
{
    class WolfHat : Item
    {
        public WolfHat() : base("item0124") // zmienić wygląd
        {
            HpMod = 20;
            ArMod = 30;
            StrMod = 30;
            GoldValue = 10;
            PublicName = "Wolf hat";
        }
    }
}

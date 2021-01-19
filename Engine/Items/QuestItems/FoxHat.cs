using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnimalItems
{
    class FoxHat : Item
    {
        public FoxHat() : base("item0130") // zmienić wygląd
        {
            HpMod = 20;
            ArMod = 30;
            PrMod = 30;
            GoldValue = 10;
            PublicName = "Fox hat";
        }
    }
}

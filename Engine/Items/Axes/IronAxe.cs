using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Axes

{
    [Serializable]
    class IronAxe : Axe
    {
        public IronAxe() : base("item1151")
        {
            StrMod = 40;
            GoldValue = 80;
            PublicName = "Iron Axe";
        }

    }
}

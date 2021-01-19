using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shields
{
    [Serializable]
    class WoodenShield : Item
    {
        public WoodenShield() : base("item1161")
        {
            ArMod = 20;
            GoldValue = 35;
            PublicName = "Wooden Shield";
        }
    }
}

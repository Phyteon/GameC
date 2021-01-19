using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shields
{
    [Serializable]
    class BasicShield : Item
    {
        public BasicShield() : base("item1225")
        {
            PublicName = "Basic Shield";
            ArMod = 10;
            GoldValue = 20;

        }
    }
}

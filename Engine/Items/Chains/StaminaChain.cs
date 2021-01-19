using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Chains
{
    [Serializable]
    class StaminaChain : Item
    {
        public StaminaChain() : base("item1188")
        {
            PublicName = "Stamina Chain";
            GoldValue = 20;
            StaMod = 30;
        }
    }
}

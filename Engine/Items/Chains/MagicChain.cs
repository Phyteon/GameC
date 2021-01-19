using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Chains
{
    [Serializable]
    class MagicChain : Item
    {
        public MagicChain() : base("item1187")
        {
            PublicName = "Magic Chain";
            GoldValue = 30;
            MgcMod = 20;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Chains
{
    [Serializable]
    class PrecisionChain : Item
    {
        public PrecisionChain() : base("item1189")
        {
            PublicName = "Precision Chain";
            GoldValue = 20;
            PrMod = 10;
        }
    }
}

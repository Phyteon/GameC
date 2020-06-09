using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Attributes
{
    [Serializable]
    class Lyre: Item
    {
        public Lyre() : base("item1363")
        {
            PublicName = "Terpsichore's Lyre";
        }
    }
}

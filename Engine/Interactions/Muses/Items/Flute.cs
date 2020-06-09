using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Attributes
{
    [Serializable]
    class Flute : Item
    {
        public Flute() : base("item1364")
        {
            PublicName = "Euterpe's Flute";
        }
    }
}

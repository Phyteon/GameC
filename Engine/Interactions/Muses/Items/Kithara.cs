using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Attributes
{
    [Serializable]
    class Kithara : Item
    {
        public Kithara() : base("item1365")
        {
            PublicName = "Erato's Kithara";
        }
    }
}

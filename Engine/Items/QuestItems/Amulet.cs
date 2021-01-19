using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Amulet
{
    class Amulet : Item
    {
        public Amulet() : base("item0131") // zmienić wygląd
        {

            PublicName = "The Heart of the Forest";
            PublicTip = "It opens the portal to the ...";
        }
    }
}

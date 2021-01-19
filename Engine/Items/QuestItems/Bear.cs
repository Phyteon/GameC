using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnimalItems
{
    class Bear : Item
    {
        public Bear() : base("item0132") // zmienić wygląd
        {
            PublicName = "Bear";
        }
    }
}

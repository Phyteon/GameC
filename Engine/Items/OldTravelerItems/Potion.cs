using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    abstract class Potion : Item
    {
        public bool IsPotion { get; protected set; } = true;
        public Potion(string name) : base(name)
        {
            IsPotion = true;
        }
    }
}

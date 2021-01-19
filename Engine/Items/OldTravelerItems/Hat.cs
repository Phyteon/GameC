using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    abstract class Hat : Item
    {
        public bool IsHat { get; protected set; } = true;
        public Hat(string name) : base(name)
        {
            IsHat = true;
        }
    }
}

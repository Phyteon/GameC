using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class OldTravelerArmor : Item
    {
        public OldTravelerArmor() : base("item1316")
        {
            PublicName = "OldTraveler Armor";
            GoldValue = 50;
            ArMod = 60;
        }

    }
}
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class CatacombsKey : Item
    {
        public CatacombsKey() : base("item0010")
        {
            
            GoldValue = 0;
            PublicName = "CatacombsKey";
            PublicTip = "A key with a skull insignia. Can opens the door to the catacombs";

        }
    }
}

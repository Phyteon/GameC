using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class OldTravelerStaff : Staff
    {
        public OldTravelerStaff() : base("item1318")
        {
            MgcMod = 13;
            GoldValue = 15;
            PublicName = "OldTraveler Staff";
        }
    }
}

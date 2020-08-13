using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class WindStaff:Staff
    {
        private int power;
        public WindStaff() : base("item0180")
        {
            PrMod = 10;
            MgcMod = 10 + power;
            GoldValue = 50;
            PublicTip = "your oponent's wind attacks give this staff more power";
            PublicName = "Wind Staff";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.air)
            {
                power += pack.HealthDmg;
            }
            return pack;
        }
    }
}

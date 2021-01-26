using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Built_In
{
    [Serializable]
    class LichsStaff : Staff
    {
        public LichsStaff() : base("item0011")
        {
            MgcMod = 100;
            GoldValue = 10;
            PublicName = "Lich's Staff";
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    // enum with damage types
    public enum DmgType
    {
        // physical 
        Cut,
        Crush,
        // magic
        Fire, 
        Air,
        Water,
        Earth,
        Psycho,
        // others
        Poison, 
        Other
    }

    public class DmgTest
    {
        // utility class for building monsters and skills
        public static bool Physical(DmgType dmg)
        {
            if (dmg == DmgType.Cut || dmg == DmgType.Crush) return true;
            else return false;
        }
        public static bool Magic(DmgType dmg)
        {
            if (dmg == DmgType.Fire || dmg == DmgType.Water || dmg == DmgType.Air || dmg == DmgType.Earth || dmg == DmgType.Psycho) return true;
            else return false;
        }

    }

}

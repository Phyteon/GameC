using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class IceEgg: Monster
    {
        public IceEgg(int eggLevel)
        {
            Health = 10;
            Strength = 0;
            Armor = 0;
            Precision = 0;
            MagicPower = 0;
            Stamina = 10;
            XPValue = eggLevel;
            Name = "monster0482";
            BattleGreetings = "You found an egg.";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Health > 0)
            {
                Stamina -= 1;
                // egg does not attack
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Crack, crack.")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "You cracked the egg!") };
            }
        }
    }
}

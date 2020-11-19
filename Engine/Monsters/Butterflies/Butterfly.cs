using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Butterfly: Monster
    {
        public Butterfly(int butterflyLevel)
        {
            Health = 10 + 4 * butterflyLevel;
            Strength = 10 + 2* butterflyLevel;
            Armor = 0;
            Precision = 15;
            MagicPower = 5;
            Stamina = 20;
            XPValue = 25 + butterflyLevel;
            Name = "monster0862";
            BattleGreetings = "I may seem insignificant but beware, I can create chaos with a few flaps of my wings!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 12;
                return new List<StatPackage>() { new StatPackage(DmgType.Air, 6 + Strength, "Butterfly uses Wings to create Wind! (" + (6 + Strength) + " magical damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Butterfly damaged its wings. It's harmless to you now.") };
            }
        }
    }
}

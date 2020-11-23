using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class VampireKnight : Monster
    {
        public VampireKnight(int vkLevel)
        {
            Health = 300 + 10 * vkLevel;
            Strength = 40 + 2 * vkLevel;
            Armor = 90;
            Precision = 80;
            Stamina = 500;
            XPValue = 100 + 3 * vkLevel;
            Name = "monster0006";
            BattleGreetings = "Greetings...";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                int chance = Index.RNG(0, 10);
                if (chance < 5)
                {
                    Stamina -= 25;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 50 + Strength, "Vampire attacks you with his sword (" + (50 + Strength) + " cut damage)") };
                }
                else
                {
                    Stamina -= 30;
                    health += 30;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Other, 70 + Strength, "Vampire drains your blood (" + (70 + Strength) + " damage) and gains 30 health"), 
                    };
                }
            }
            else
            {
                stamina += 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Vampire is exhausted, he has to rest") };
            }
        }
    }
}

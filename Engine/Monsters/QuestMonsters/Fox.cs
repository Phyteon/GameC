using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class Fox : Monster
    {
        public Fox()
        {
            Health = 10; //40
            Strength = 20;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 80;
            XPValue = 150;
            Name = "monster0024";
            BattleGreetings = "Grr...!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 10)
            {
                int chance = Index.RNG(0, 10);
                if (chance < 2)
                {
                    Stamina -= 40;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 50 + Strength, "Fox bites your throat (" + (50 + Strength) + " cut damage)") };
                }
                else
                {
                    Stamina -= 30;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Other,  Strength, "Fox bites your leg (" + (+ Strength) + " damage) and gains 30 health"),
                    };
                }
            }
            else
            {
                stamina += 40;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Fox is exhausted, he has to rest") };
            }
        }
    }
}

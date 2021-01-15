using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Mandragorian : Monster
    {
        public Mandragorian()
        {
            Health = 100;
            Strength = 30;
            Armor = 50;
            Precision = 100;
            MagicPower = 30;
            Stamina = 150;
            XPValue = 55;
            Name = "monster1507";
            BattleGreetings = "Let's get to the root of the problem why you killed my child!"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina >= 30)
            {
                int chance = Index.RNG(0, 10);
                if (chance <= 5)
                {
                    Stamina -= 25;
                    health += 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Cut, 20 + Strength, "Mandragorian attacks you with his roots (" + (20 + Strength) + " cut damage)")
                    };
                }
                else if (chance < 5 && chance > 9)
                {
                    Stamina -= 30;
                    health += 15;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 30 + MagicPower, "Mandragorian gets into your mind and drains you out of your energy. (" + (30 + MagicPower) + " psycho damage) ")
                    };
                }
                else
                {
                    Stamina -= 30;
                    health += 20;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Earth, 20 + Strength, "Mandragorian suffocates you with its roots (" + (20 + Strength) + " damage) and gains 20 health"),
                    };
                }
            }
            else if (Stamina >= 5 && Stamina < 30)
            {
                if (Health > 45)
                {
                    Stamina -= 5;
                    health += 10;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5 + MagicPower, " Mandragorian manipulates you to stab yourself (" + (5 + MagicPower) + " psycho damage) and gains 10 health. ")
                    };
                }
                else
                {
                    Stamina -= 10;
                    health += 20;
                    return new List<StatPackage>()
                    {  new StatPackage(DmgType.Earth, 5 + Strength, " Mandragorian used its roots (" + (5 + Strength) + " damage) and gains 20 health.  ") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Mandragorian is exhausted. Mandragorian needs sleep.") };
            }
        }
    }
}
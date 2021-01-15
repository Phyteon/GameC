using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class MainWitch : Monster
    {
        public MainWitch()
        {
            Health = 10; //100
            Strength = 10;
            Armor = 0;
            Precision = 50;
            MagicPower = 50;
            Stamina = 100;
            XPValue = 300;
            Name = "monster0025";
            BattleGreetings = "Die you scum!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Health > 30)
                if (Stamina > 20)
                {
                    int chance = Index.RNG(0, 10);
                    if (chance < 5)
                    {
                        Stamina -= 40;
                        return new List<StatPackage>() { new StatPackage(DmgType.Cut, 20 + MagicPower, "Witch uses bloodball! (" + (20 + MagicPower) + " magic damage)") };
                    }
                    else
                    {
                        Stamina -= 30;
                        return new List<StatPackage>() { new StatPackage(DmgType.Fire, MagicPower, "Witch sets you on fire! (" + (MagicPower) + " fire damage)") };
                    }
                }
                else 
                {
                    Stamina += 40;
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Witch is resting!") };
                }

            else if(Health < 30 && Health > 20)
            {
                health += 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Witch healed herself!") };
            }
            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "idk") };
        }
    }
}

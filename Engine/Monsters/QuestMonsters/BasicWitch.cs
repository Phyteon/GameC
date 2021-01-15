using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class BasicWitch : Monster
    {
        public BasicWitch()
        {
            Health = 10; //40
            Strength = 10;
            Armor = 0;
            Precision = 50;
            MagicPower = 50;
            Stamina = 100;
            XPValue = 100;
            Name = "monster0020";
            BattleGreetings = "Die you scum!"; 
        }

             public override List<StatPackage> BattleMove()
        {
            if (Stamina > 20)
            {
                Stamina -= 40;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 15 + MagicPower, "Witch uses bloodball! (" + (15 + MagicPower) + " magic damage)") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Witch hits you with her dagger! (" + (5 + Strength) + " cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Witch doesn't have energy to hit you!") };
            }
        }
    }
}

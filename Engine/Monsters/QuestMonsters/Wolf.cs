using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class Wolf : Monster
    {
        public Wolf()
        {
            Health = 10; //80
            Strength = 40;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 60;
            XPValue = 150;
            Name = "monster0023";
            BattleGreetings = "Grr...!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength, "Wolf bites your leg! (" + (Strength) + " cut damage)") };
            }

            else
            {
                health += 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Wolf escaped for a second and came back with more health!") };
            }
        }
    }
}

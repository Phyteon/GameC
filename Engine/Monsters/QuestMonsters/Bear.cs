using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class Bear : Monster
    {
        public Bear()
        {
            Health = 10; //300
            Strength = 20;
            Armor = 0;
            Precision = 20;
            MagicPower = 0;
            Stamina = 180;
            XPValue = 150;
            Name = "monster0022";
            BattleGreetings = "Grr..!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 20)
            {
                Stamina -= 40;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength, "Bear hits you with it's paw! (" + (Strength) + " cut damage)") };
            }
            if (Stamina > 10 && Stamina <= 20)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 20 + Strength, "Bear bits you! (" + (20 + Strength) + " cut damage)") };

            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Bear doesn't have energy to hit you!") };
            }
        }
    }
}

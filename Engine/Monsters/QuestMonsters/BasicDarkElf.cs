using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class BasicDarkElf : Monster
    {
        public BasicDarkElf()
        {
            Health = 10; //60
            Strength = 20;
            Armor = 0;
            Precision = 50;
            MagicPower = 90;
            Stamina = 50;
            XPValue = 100;
            Name = "monster0021";
            BattleGreetings = "Die you scum!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 20)
            {
                Stamina -= 40;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, MagicPower, "Dark Elf uses ! (" + (MagicPower) + " magic damage)") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength, "Dark Elf hits you with poisoned dagger! (" + ( Strength) + " cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Dark Elf doesn't have energy to hit you!") };
            }
        }
    }
}

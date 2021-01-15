using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class MainDarkElf : Monster
    {
        public MainDarkElf()
        {
            Health = 10; //200
            Strength = 10;
            Armor = 10;
            Precision = 50;
            MagicPower = 30;
            Stamina = 100;
            XPValue = 300;
            Name = "monster0026";
            BattleGreetings = "Die you scum!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Health > 50 || Health <=10)
                if (Stamina > 20)
                {
                    int chance = Index.RNG(0, 10);
                    if (chance < 5)
                    {
                        Stamina -= 30;
                        return new List<StatPackage>() { new StatPackage(DmgType.Poison,  MagicPower+ Strength, "Dark Elf hits you with poisoned sword! (" + (MagicPower + Strength) + " poison damage)") };
                    }
                    else
                    {
                        Stamina -= 20;
                        return new List<StatPackage>() { new StatPackage(DmgType.Fire, MagicPower, "Dark Elf uses lightning! (" + (MagicPower) + " magic damage)") };
                    }
                }
                else
                {
                    Stamina += 40;
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "DarkElf is resting!") };
                }

            else if (Health < 30 && Health >10)
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 100, "Dark Elf stabbed you in the back with magic dagger! (" + (MagicPower) + " cut damage)" )};
            }
            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "idk") };
        }
    }
}

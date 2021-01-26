using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Built_In
{
    class Lich : Monster
    {
        public Lich()
        {
            Health = 500;
            Strength = 50;
            Armor = 50;
            Precision = 60;
            Stamina = 1000;
            XPValue = 500;
            Name = "monster0037";
            BattleGreetings = "";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                int chance = Index.RNG(0, 10);

                if (chance < 3)
                {
                    Stamina -= 50;
                    health += 30;
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 30 + precision, "Lich drains you with his magic (" + (30 + precision) + " dark damage)") };

                }

                if (chance < 7 && chance >= 3)
                {
                    Stamina -= 30;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 20 + precision, "Lich summons poisonous mist (" + (20 + precision) + " poison damage)") };

                }
                else
                {
                    Stamina -= 100;
                    return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 50 + Precision, "Lich summons the vortex of darkness (" + (50 + Precision) + "dark damage)") };
                }



            }
            else
            {
                stamina += 50;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Necromancer is exhausted, he has to rest") };
            }
        }
    }
}

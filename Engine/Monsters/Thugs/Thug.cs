using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Thug:Monster
    {
        int Counter = 0;
        public Thug(int thugLevel)
        {
            Health = 50 + 10 * thugLevel;
            Strength = 20 + 2 * thugLevel;
            Armor = 10;
            Precision = 50;
            MagicPower = 0;
            Stamina = 100;
            XPValue = 40 + 3 * thugLevel;
            Name = "monster0621";
            BattleGreetings = "Oh gods, a battle!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Counter == 0)
            {
                if (Stamina >= 15)
                {
                    Stamina -= 15;

                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Thug uses his knife! (" + (10 + Strength) + " cut damage)") };
                }
                else
                {
                    return new List<StatPackage>()
                    {
                         new StatPackage(DmgType.Other, 0, "Thug has no energy to attack anymore!")
                    };
                }
            }
            else
            {
                Counter = 0;
                return new List<StatPackage>()
                {
                     new StatPackage(DmgType.Other, 0, "Thug is scared and needs to calm down!")
                };
            }

        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
                if (pack.HealthDmg > (Health / 2))
                {
                    Counter++;
                }
            }
        }
    }
}

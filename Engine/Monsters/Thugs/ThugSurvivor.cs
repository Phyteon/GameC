using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class ThugSurvivor:Monster
    {
        int Counter = 0;
        public ThugSurvivor(int thugLevel)
        {
            
            Health = 30 + 7 * thugLevel;
            Strength = 15 + 1 * thugLevel;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 60;
            XPValue = 60 + thugLevel;
            Name = "monster0622";
            BattleGreetings = "I ain't finished with you yet!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina >= 15)
            {
                Stamina -= 15;
                return new List<StatPackage>()
                { 
                    
                new StatPackage(DmgType.stab, 10 + Strength, "Thug uses his knife! (" + (10 + Strength) + " stab damage)"),
                new StatPackage(DmgType.none, 30, "A thug beats you very furiously! (30 hit damage)")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                     new StatPackage(DmgType.none, 0, "Thug has no energy to attack anymore!")
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

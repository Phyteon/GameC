using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Boulder : Monster
    {
        private bool tryCriticalHit = false;
        private bool heal = false;
        public Boulder()
        {
            Health = 50;
            Strength = 60;
            Armor = 5;
            Precision = 0;
            Stamina = 100;
            XPValue = 50;
            Name = "monster1442";
            BattleGreetings = "You can't beat me. I'm too strong!";
        }
        
          
        public override List<StatPackage> BattleMove()
        {
            if (tryCriticalHit)
            {
                Stamina -= 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush,  Strength, "Boulder tries critical hit (" + (Strength) + " crush damage)") };
            }
            if (heal)
            {
                Health = 70;               
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Boulder resets its health!") };
            }

            if (Strength > 15) 
            {
                if (Stamina > 70)
                {
                    Stamina -= 15;
                    return new List<StatPackage>() { new StatPackage(DmgType.Crush, 15 + Strength, "Boulder crushed you (" + (15 + Strength) + " crush damage)") };
                }
                if (Stamina <= 70 && Stamina > 0)
                {
                     Stamina -= 10;                  
                     return new List<StatPackage>() { new StatPackage(DmgType.Other, 10 + Strength, "Boulder hits you with its fist (" + (15 + Strength) + " damage)") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Boulder is exhausted and fell of its feet!" )};
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Boulder is exhausted and fell of its feet!") };
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
               
            }
            if(Health < 40 && Health%3 ==0)
            {
                this.tryCriticalHit = true;
            }
            if (Health == 34)
            {
                int chance = Index.RNG(0, 100);
                if (chance < 11) heal = true;
            }

        }
    }
}

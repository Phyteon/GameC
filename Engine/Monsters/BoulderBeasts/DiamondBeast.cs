using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class DiamondBeast : Monster
    {
        private bool waterHit;
        private bool heal;
        public DiamondBeast()
        {
            Health = 350;
            Strength = 100;
            Armor = 100;
            Precision = 50;
            MagicPower = 50;
            Stamina = 250;
            XPValue = 90;
            Name = "monster1446";
            BattleGreetings = "I'm invincible!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (waterHit)
            {
                Strength -= 10;
                Precision -= 25;
                return new List<StatPackage>() { new StatPackage(DmgType.Water, 10 + Strength, "Diamond beast uses its special water hit (" + (10 + Strength) + " damage)") };
            }
            if (heal)
            {
                Health += 50;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Diamond beast gains 50 Health !") };
            }
            if (Armor > 60)
            {
                int chance = Index.RNG(0, 11);

                if (chance > 5)
                {
                    Armor -= 10;
                    Stamina -= 25;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, MagicPower, "Diamond beast uses cut (" + (MagicPower) + " damage)") };
                }
                if (chance == 4 || chance == 5)
                {
                    Armor -= 15;
                    Stamina -= 40;
                    return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 0, "Diamond beast tries to persuade you to lay down your weapon (0 damage)") };
                }
                if (chance < 2)
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Water, 5 + MagicPower, "Diamond beast traps you in a water ball (" + (5 + MagicPower) + " damage) ") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Diamond beast is exhausted!") };
                }

            }
            else
            {
                Stamina -= 40;
                int chance = Index.RNG(0, 3);
                switch (chance)
                {
                    case 1:
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Diamond beast traps you in a water ball (" + (5 + MagicPower) + " damage)") };
                    default:
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Diamond beast is exhausted!") };

                }


            }
        }
        public override void React(List<StatPackage> packs) 
        {
            foreach (StatPackage pack in packs)
            {
                Health -= 2*pack.HealthDmg;
                Strength -= 2*pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }
            if (Health < 20)
            {
                int a = Index.RNG(0, 2);
                if(a == 0)
                {
                    waterHit = true;
                }
                else
                {
                    heal = true;
                }               

            }
            
        }
       

    }
}

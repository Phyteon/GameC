using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Basilisk : Monster
    {
        public Basilisk()
        {
            Health = 120;
            Strength = 30;
            Armor = 70;
            Precision = 80;
            MagicPower = 40;
            Stamina = 130;
            XPValue = 150;
            Name = "monster1182";
            BattleGreetings = "Look me in the eyessss";
        }


        public override List<StatPackage> BattleMove()
        {
            if (Health > 50)
            {
                if (Stamina > 75)
                {
                    Stamina -= 15;
                    MagicPower -= 5;
                    return new List<StatPackage>() 
                    { 
                        new StatPackage(DmgType.Psycho, Strength, "Basilisk attacks from nowhere! " + (Strength) + " damage"),
                        new StatPackage(DmgType.Other, 10, "You have been turned into stone (" +10+ " damage)"),
                        new StatPackage(DmgType.Cut, 10, "Basilisk bites!" + 10 + "(cut damage)")
                    };
                }

                if (Stamina > 0 && Stamina <= 75)
                {
                    Stamina -= 10;
                    Health -= 10;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Poison, 15 + MagicPower, "Basilisk's poison burns your body! " + (15 + MagicPower) + " (poison damage)"),
                        new StatPackage(DmgType.Crush, 10 + Health, "Basilisk crushes your body!"+ (10 + Health) + "(crush damage)")
                    };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Basilisk has less energy to attack!") };
                }
            }
            else
            {
                if (Stamina > 0)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Basilisk bites you! " + (10 + Strength) + " (cut damage)") };
                }

                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Basilisk has no energy to attack anymore!") };
                }
            }


        }

        

        public override void React(List<StatPackage> packs)
        {
            int numberOfAttacks = Index.RNG(0, 101);
            if (numberOfAttacks < 57)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Precision -= pack.PrecisionDmg;
                    Armor -= pack.ArmorDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
            }
            else if (numberOfAttacks <= 57 && numberOfAttacks > 23)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Armor -= pack.ArmorDmg;
                    Strength -= pack.StrengthDmg;
                }
            }
            else
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                }
            }
        }
    }
}

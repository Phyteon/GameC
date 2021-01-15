using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class BoulderBeast : Monster
    {
        private bool finalHit=false;
        private bool heal = false;
        public BoulderBeast()
        {
            Health = 80;
            Strength = 60;
            Armor = 10;
            Precision = 8;
            Stamina = 130;
            XPValue = 70;
            Name = "monster1443";
            BattleGreetings = "I will smash you!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (finalHit)
            {
                Strength = 0;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush, 10 + Strength, "Boulder beast hits you with its final hit (" + (2 + Strength) + " damage)") };
            }
            if (heal)
            {
                Stamina = 130;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush, 10 + Strength, "Boulder beast resets its stamina!") };
            }
            if (Armor > 6)
            {
                int chance = Index.RNG(0, 11);

                if (chance < 5)
                {
                    Armor -= 1;
                    Stamina -= 20;
                    return new List<StatPackage>() { new StatPackage(DmgType.Earth, 13 + Strength, "Boulder beast caused an earthquake and you fell (" + (13 + Strength) + " damage)") };
                }
                if (chance == 5 || chance == 6)
                {
                    Armor -= 2;
                    Stamina -= 30;
                    return new List<StatPackage>() { new StatPackage(DmgType.Earth, 0, "The ground cracked, but you managed to jump over the crack (0 damage)") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Boulder beast is too tired to fight!") };
                }

            }
            else
            {
                Stamina -= 40;
                int chance = Index.RNG(0, 3);
                switch (chance)
                {
                    case 2:
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Boulder beast caused an earthquake and you fell (" + (5 + Strength) + " damage)") };
                    default:
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Boulder beast is too tired to fight!") };

                }


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
            if (Health < 20)
            {
                finalHit = true;
            }
            if (Health == 21)
            {
                int chance = Index.RNG(0, 100);
                if (chance > 11 && chance < 20) heal = true;
            }
        }
    } 
}

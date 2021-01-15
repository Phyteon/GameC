using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Medusa : Monster
    {
        public Medusa()
        {
            Health = 60;
            Strength = 15;
            Armor = 10;
            Precision = 65;
            MagicPower = 15;
            Stamina = 75;
            XPValue = 45;
            Name = "monster1183";
            BattleGreetings = "Ssssss You think you can win?! You ain't Perseus...";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 60)
            {
                Stamina -= 15;
                return new List<StatPackage>() 
                { new StatPackage(DmgType.Psycho, 15 + Strength, "Medusa uses Psycho powers! You will turn into stone... " + (15 + Strength) + " (psycho damage)")
                 };
            }

            if (Stamina > 30 && Stamina <= 60)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 10 + Strength, "Medusa uses Psycho powers! You are hypnotized! " + (5 + Strength) + "(psycho damage)") };
            }

            if (Stamina > 0 && Stamina <= 30)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Medusa uses her snakes! (" + (5 + Strength) + " cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Medusa has no energy to attack anymore!") };
            }
        }

        private int attacksNumber = 0;
        public override void React(List<StatPackage> packs)
        {
            attacksNumber++;
            if (attacksNumber == 1)
            {
                foreach (StatPackage pack in packs)
                {

                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    attacksNumber++;

                }
            }
            else if (attacksNumber == 2)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    attacksNumber++;
                }
            }
            else if (attacksNumber >= 3)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    attacksNumber++;
                }
            }
        }


    }
}

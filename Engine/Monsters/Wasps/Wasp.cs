
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Wasp : Monster
    {
        public Wasp()
        {
            Health = 60;
            Strength = 20;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 60;
            XPValue = 25;
            Name = "monster1240";
            BattleGreetings = null; 
        }


        public override List<StatPackage> BattleMove()
        {
           
            if (Stamina > 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush, 15 + Strength, "Wasp hits you with the antennaes! (" + (15 + Strength) + " crush damage)") };
            }

            if (Stamina > 20 && Stamina <= 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Wasp hits you with the wings! (" + (5 + Strength) + " cut damage)") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Poison, 5 + Strength, "Wasp uses sting! (" + (5 + Strength) + " poison damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Wasp has no energy to attack anymore!") };
            }

        }
        public override void React(List<StatPackage> packs) 
        {

            foreach (StatPackage pack in packs)
            {
                if (Health > 30)
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
                else
                {
                    Health -= 15;
                }
            }
        }
    }
}

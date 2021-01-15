using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class MagicWasp : Monster
    {
        public MagicWasp()
        {
            Health = 120;
            Strength = 15;
            Armor = 0;
            Precision = 50;
            MagicPower = 60;
            Stamina = 70;
            XPValue = 50;
            Name = "monster1241";
            BattleGreetings = "Now I'm back... with magic powers!"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (MagicPower > 10)
            {
                if (Stamina > 50)
                {
                    MagicPower -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Air, 15 + Strength, "MagicWasp uses Air! (" + (15 + Strength) + " Air damage)") };
                }

                if (Stamina > 0 && Stamina <= 50)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 5 + Strength, "MagicWasp uses sting! (" + (5 + Strength) + " poison damage)") };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "MagicWasp has no energy to attack anymore!") };
                }
            }
            else
            {
                if (Stamina > 0)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 5 + Strength, "MagicWasp uses sting! (" + (5 + Strength) + " poison damage)") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "MagicWasp has no energy to attack anymore!") };
                }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Numi : Monster
    {
        public Numi(int numiLevel)
        {
            Health = 60 + 5 * numiLevel;
            Strength = 10 + numiLevel;
            Armor = 0;
            Precision = 50;
            MagicPower = 20 + 2*numiLevel;
            Stamina = 70;
            XPValue = 35 + numiLevel;
            Name = "monster1360";
            BattleGreetings = "Be careful. Every physical hit makes me stronger!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Water, MagicPower, "Numi uses Water Ring Spell! (" + (MagicPower) + " magic damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Numi has no energy to attack anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Cut)
                {
                    Health -= pack.HealthDmg*50/100;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision += pack.HealthDmg * 20 / 100;
                    MagicPower += pack.HealthDmg * 40 / 100;
                }
                else
                {
                    health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
                
                
            }
        }
    }
}

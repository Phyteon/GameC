using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Numidex : Monster 
    {
        public Numidex(int numidexLevel)
        {
            Health = 80 + 5 * numidexLevel;
            Strength = 30 + numidexLevel;
            Armor = 20;
            Precision = 50 + numidexLevel;
            MagicPower = 40 + 2 * numidexLevel;
            Stamina = 90;
            XPValue = 55 + numidexLevel;
            Name = "monster1361";
            BattleGreetings = "Welcome back. You defeated me but now I'm stronger!\nShow me what you got!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 60)
            {
                Stamina -= 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Water, MagicPower + Precision / 2 ,0 , MagicPower/4 ,2 ,0 , "Numidex uses Ice bolt! (" + (MagicPower + Precision / 2) + " magic damage)") };
            }
            if (Stamina > 20)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Water, MagicPower + Precision / 6, "Numidex uses Water Ball! (" + (MagicPower + Precision / 6) + " magic damage)") };
            }
            if(Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Water, 5 + MagicPower, "Numidex uses Water Ring Spell! (" + (5 + MagicPower) + " magic damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Numidex has no energy to attack anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Cut)
                {
                    Health -= pack.HealthDmg * 50 / 100;
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

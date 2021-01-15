using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Boar : Monster
    {
        public Boar()
        {
            Health = 80;
            Strength = 20;
            Armor = 0;
            Precision = 40;
            MagicPower = 0;
            Stamina = 30;
            XPValue = 40;
            Name = "monster1284";
            BattleGreetings = "Grunt!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 14) 
            {
                int chance = Index.RNG(0, 2);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength*1/2, "Boar bites you! (" + (10 + Strength * 1 / 2) + "cut damage)") };
                    case 1:
                        Stamina -= 15;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Boar dashes at you! (" + (5 + Strength) + "other damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength*1/2, "Boar attacks you with its snout! (" + (5 + Strength * 1 / 2) + "other damage)") };
                }
            }
            else if (Stamina > 0 && Stamina < 15)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength*1/2, "Boar attacks you with its leg! (" + Strength * 1 / 2 + "other damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Boar is so tired that it has no stamina to attack anymore!") };
            }
        }

        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                int dmgHealth = (pack.HealthDmg - Armor);
                if (dmgHealth < 0)
                    dmgHealth = 0;
                Health -= dmgHealth;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
                if (Health < 40)
                {
                    Strength = Strength*3/2;
                    Precision = Precision*3/4;
                }
            }

        }
    }
}

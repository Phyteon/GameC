using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Chinchilla : Monster
    {
        public Chinchilla()
        {
            Health = 50;
            Strength = 20;
            Armor = 5;
            Precision = 70;
            Stamina = 100;
            XPValue = 25;
            Name = "monster1160";
            BattleGreetings = "Squeak!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 14)
            {
                int chance = Index.RNG(0,4);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5,0,0,10,0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla throws sand in your eyes (" + 5 + " damage and -10 precision)") };
                    case 1:
                        Stamina -= 15;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla bites you (" + Strength + " damage)") };
                    case 2:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla throws poo at you (" + (5 + Strength) + " damage)") };
                    default:
                        Stamina += 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla dodges (0 damage)") };
                }
            }
            else if (Stamina > 9 && Stamina <15)
            {
                int chance = Index.RNG(0, 3);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5, 0, 0, 10, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla throws sand in your eyes (" + 5 + " damage and -10 precision)") };
                    case 1:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla throws poo at you (" + (5 + Strength) + " damage)") };
                    default:
                        Stamina += 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla dodges (0 damage)") };
                }
            }
            if (Stamina > 4 && Stamina< 10)
            {
                int chance = Index.RNG(0, 3);
                switch (chance)
                {
                    case 1:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla throws poo at you (" + (5 + Strength) + " damage)") };
                    default:
                        Stamina += 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla dodges (0 damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla has no energy.") };
            }
        }
        private int dmgToMonster = 0;
        public override void React(List<StatPackage> packs)
        {
            dmgToMonster = 0;
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
                dmgToMonster += dmgHealth + pack.StrengthDmg + pack.ArmorDmg + pack.PrecisionDmg + pack.MagicPowerDmg;
            }
        }
    }
}

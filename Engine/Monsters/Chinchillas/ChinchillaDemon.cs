using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class ChinchillaDemon : Monster
    {
        public ChinchillaDemon()
        {
            Health = 100;
            Strength = 30;
            Armor = 15;
            Precision = 70;
            MagicPower = 60;
            Stamina = 150;
            XPValue = 45;
            Name = "monster1162";
            BattleGreetings = "Your nightmares come true! I'm a chinchilla demon!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (tura == true)
            {
                if (a < 2)
                {
                    if (a == 0)
                    {
                        Stamina -= 15;
                        a = 1;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "The two-turn attack starts.  Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon bites you (" + Strength + " damage)") };
                        
                    }
                    else 
                    {
                        Stamina -= 15;
                        a = 0;
                        tura = false;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "The two-turn attack continues. Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon bites you (" + Strength + " damage)") };
                        
                    }
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "The two-turn attack failed. ") };
                }
            }
            else
            {
                if (Stamina > 14)
                {
                    int chance = Index.RNG(0, 4);
                    switch (chance)
                    {
                        case 0:
                            Stamina -= 10;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 5, 0, 0, 10, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon throws sand in your eyes (" + 5 + " damage and -10 precision)") };
                        case 1:
                            Stamina -= 15;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon bites you (" + Strength + " damage)") };
                        case 2:
                            Stamina -= 5;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon throws poo at you (" + (5 + Strength) + " damage)") };
                        default:
                            Stamina += 5;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon dodges (0 damage)") };
                    }
                }
                else if (Stamina > 9 && Stamina < 15)
                {
                    int chance = Index.RNG(0, 3);
                    switch (chance)
                    {
                        case 0:
                            Stamina -= 10;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 5, 0, 0, 10, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon throws sand in your eyes (" + 5 + " damage and -10 precision)") };
                        case 1:
                            Stamina -= 5;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon throws poo at you (" + (5 + Strength) + " damage)") };
                        default:
                            Stamina += 5;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon dodges (0 damage)") };
                    }
                }
                if (Stamina > 4 && Stamina < 10)
                {
                    int chance = Index.RNG(0, 3);
                    switch (chance)
                    {
                        case 1:
                            Stamina -= 5;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon throws poo at you (" + (5 + Strength) + " damage)") };
                        default:
                            Stamina += 5;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon dodges (0 damage)") };
                    }
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Chinchilla demon has no energy.") };
                }
            }
            
        }
        private int dmgToMonster = 0;
        private bool tura = false;
        private int a = 0;
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
            if (Health > 60 && Stamina > 29)
            {
                tura = true;
            }
        }
    }
}

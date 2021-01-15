using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class CatWizard : Monster
    {
        public CatWizard()
        {
            Health = 140;
            Strength = 20;
            Armor = 25;
            Precision = 50;
            MagicPower = 50;
            Stamina = 70;
            XPValue = 55;
            Name = "monster1164";
            BattleGreetings = "Meow! I'm a Cat Wizard! Prepare to die!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 39)
            {
                Armor = 25;
                int chance = Index.RNG(0, 5);
                switch (chance)
                {
                    case 0:
                        Stamina -= 40;
                        return new List<StatPackage>() { new StatPackage(DmgType.Fire, 10 + MagicPower, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard attacks you with fire magic (" + (10 + MagicPower) + " damage)") };
                    case 1:
                        Stamina -= 40;
                        return new List<StatPackage>() { new StatPackage(DmgType.Water, 10 + MagicPower, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard attacks you with water magic (" + (10 + MagicPower) + " damage)") };
                    case 2:
                        Stamina -= 40;
                        return new List<StatPackage>() { new StatPackage(DmgType.Air, 10 + MagicPower, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard attacks you with air magic (" + (10 + MagicPower) + " damage)") };
                    case 3:
                        Stamina -= 40;
                        return new List<StatPackage>() { new StatPackage(DmgType.Earth, 10 + MagicPower, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard attacks you with earth magic (" + (10 + MagicPower) + " damage)") };
                    default:
                        Stamina -= 15;
                        Armor = Armor + 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard dodges (0 damage)") };
                }
            }
            else if (Stamina > 9 & Stamina < 40)
            {
                Armor = 25;
                int rest = 0;
                if (Health > 50) 
                {
                    rest = Index.RNG(0, 3);
                }
                if (rest == 0)
                {
                    int chance = Index.RNG(0, 2);
                    switch (chance)
                    {
                        case 0:
                            Stamina -= 10;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard scratches you (" + Strength + " damage)") };
                        default:
                            Stamina -= 5;
                            Armor = Armor + 10;
                            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard dodges (0 damage)") };
                    }
                }
                else
                {
                    Stamina += 30;
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard has to rest.") };
                }

            }
            else if (Stamina > 4 & Stamina < 10)
            {
                Stamina -= 5;
                Armor = Armor + 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard dodges (0 damage)") };
            }
            else
            {
                Stamina += 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Cat wizard has no energy to fight and he has to rest.") };
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class BlackCat : Monster
    {
        public BlackCat()
        {
            Health = 40;
            Strength = 25;
            Armor = 10;
            Precision = 50;
            Stamina = 120;
            XPValue = 30;
            Name = "monster1163";
            BattleGreetings = "Meow!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 19)
            {
                Armor = 10;
                int chance = Index.RNG(0, 2);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat scratches you (" + Strength + " damage)") };
                    case 1:
                        Stamina -= 20;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 10 + Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat bites you (" + (10 + Strength) + " damage)") };
                    default:
                        Stamina -= 5;
                        Armor = Armor + 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat dodges (0 damage)") };
                }
            }
            else if (Stamina > 9 && Stamina < 20)
            {
                Armor = 10;
                int chance = Index.RNG(0, 2);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat scratches you (" + Strength + " damage)") };
                    default:
                        Stamina -= 5;
                        Armor = Armor + 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat dodges (0 damage)") };
                }
            }
            else if (Stamina > 4 && Stamina < 10)
            {
                Stamina -= 5;
                Armor = Armor + 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat dodges (0 damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Black cat has no energy to fight!") };
            }
        }
        private int dmgToMonster = 0;
        public override void React(List<StatPackage> packs)
        {
            dmgToMonster = 0;            
            foreach (StatPackage pack in packs)
            {
                int dmgHealth = pack.HealthDmg * 100 / (100 + Armor);
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

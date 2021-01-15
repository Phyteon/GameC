using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class ChinchillaAngel : Monster
    {
        public ChinchillaAngel()
        {
            Health = 600;
            Strength = 3;
            Armor = 600;
            Precision = 50;
            MagicPower = 100;
            Stamina = 10;
            XPValue = 150;
            Name = "monster1161";
            BattleGreetings = "It's an Angel and ... a chinchilla";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Health > 0)
            {
                Health = 0; 
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Angel chinchilla gives you a lot of XP") };  
            }
            else
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Monster has an armor, you did " + dmgToMonster + " damage. Angel chinchilla gives you a lot of XP") };
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

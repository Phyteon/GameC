using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class CursedMirror : Monster
    {
        public CursedMirror()
        {
            Health = 60;
            Strength = 5;
            Armor = 10;
            Precision = 60;
            MagicPower = 10;
            Stamina = 40;
            XPValue = 50;
            Name = "monster1280";
            BattleGreetings = "Look at me, if you dare" ; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 19)
            {
                int chance = Index.RNG(0, 3);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 10 + Strength, "Cursed Mirror attacks you with its frame! (" + (10 + Strength) + " other damage)") };
                    case 1:
                        Stamina -= 20;
                        return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 15 + MagicPower, "Cursed Mirror shocks you with a demonic reflection of you! (" + (15 + MagicPower) + "psycho damage") };
                    case 2:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Cursed Mirror attacks you with its sharp edge! (" + (5 + Strength) + "cut damage)") };
                    default:
                        Stamina += 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Cursed Mirror regains a part of its stamina!") };
                }
            }
            else if (Stamina > 9 && Stamina < 20) 
            {
                int chance = Index.RNG(0, 3);
                switch (chance) 
                {
                    case 0:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, 0, 0, MagicPower*1/2, 0, "Cursed Mirror blinds you by reflecting a sun ray right into your eyes! (precision lowered by " + (MagicPower*1/2) + ")") };
                    case 1:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Cursed Mirror attacks you with its leg! (" + (Strength) + "other damage)") };
                    case 2:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, dmgTaken * 1 / 2, "Cursed Mirror uses its reflective properties to attack you based on the damage it took! (" + dmgTaken * 1 / 2 + "other damage)") };
                    default:
                        Stamina += 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Cursed Mirror regains some stamina!") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Cursed Mirror has no stamina to attack anymore!") };
            }
        }
        
        private int dmgTaken = 0;
        public override void React(List<StatPackage> packs)
        {
            dmgTaken = 0;
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
                dmgTaken += dmgHealth + pack.StrengthDmg + pack.ArmorDmg + pack.PrecisionDmg + pack.MagicPowerDmg;
            }

        }
    }
}

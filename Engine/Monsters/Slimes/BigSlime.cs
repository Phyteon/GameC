using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class BigSlime : Monster
    {
        // example monster: rat
        public BigSlime()
        {
            Health = 80;
            Strength = 40;
            Armor = 0;
            Precision = 60;
            MagicPower = 20;
            Stamina = 50;
            XPValue = 60;
            Name = "monster1283";
            BattleGreetings = "It is time to put an end to your slaughter!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 24)
            {
                int chance = Index.RNG(0, 2);
                switch (chance)
                {
                    case 0:
                        Stamina -= 25;
                        return new List<StatPackage>() { new StatPackage(DmgType.Fire, 20 + MagicPower*2, "Big Slime attacks you using a fire spell (" + (20 + MagicPower*2) + "fire damage)") };
                    case 1:
                        Stamina -= 15;
                        return new List<StatPackage>() { new StatPackage(DmgType.Fire, Strength + MagicPower*2, "Big Slime attacks you with a slimy substance it is made of! (" + (Strength + MagicPower*2) + "fire damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength, "Big Slime attacks you with its head! (" + (Strength) + "other damage)") };
                }
            }
            else if (Stamina > 0 && Stamina < 25)
            {
                int chance = Index.RNG(0, 1);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Fire, 20 + Strength, "Big Slime attack you with a fiery breath! (" + (20 + Strength) + "fire damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, Strength*2, "Big Slime jumps on you, crushing you with its huge body! (" + (Strength*2) + "crush damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Big Slime is out of stamina and cannot continue its vengeance!") };
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
            }

        }
    }
}

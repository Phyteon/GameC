using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class MediumSlime : Monster
    {
        // example monster: rat
        public MediumSlime()
        {
            Health = 40;
            Strength = 20;
            Armor = 0;
            Precision = 60;
            MagicPower = 10;
            Stamina = 50;
            XPValue = 30;
            Name = "monster1282";
            BattleGreetings = "It will not be a happy medium";
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
                        return new List<StatPackage>() { new StatPackage(DmgType.Water, 15 + MagicPower*3/2, "Medium Slime attacks you using a water spell (" + (15 + MagicPower*3/2) + "water damage)") };
                    case 1:
                        Stamina -= 15;
                        return new List<StatPackage>() { new StatPackage(DmgType.Water, Strength*3/4 + MagicPower*3/2, "Medium Slime attacks you with a slimy substance it is made of! (" + (Strength*3/4 + MagicPower*3/2) + "water damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength*3/4, "Medium Slime attacks you using its head! (" + (Strength*3/4) + "other damage)") };
                }
            }
            else if (Stamina > 0 && Stamina < 25)
            {
                int chance = Index.RNG(0, 1);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Water, 15 + Strength*3/4, "Medium Slime spits out a mouthful of water at you! (" + (15 + Strength*3/4) + "water damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, Strength*3/2, "Medium Slime jumps on you, almost crushing you! (" + (Strength*3/2) + "crush damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Medium Slime ran out of stamina and cannot attack anymore!") };
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class SmallSlime : Monster
    {
        // example monster: rat
        public SmallSlime()
        {
            Health = 20;
            Strength = 10;
            Armor = 0;
            Precision = 60;
            MagicPower = 5;
            Stamina = 50;
            XPValue = 15;
            Name = "monster1281";
            BattleGreetings = "Good things come in small packages!";
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
                        return new List<StatPackage>() { new StatPackage(DmgType.Earth, 10 + MagicPower, "Small Slime attacks you using an earth spell (" + (10 + MagicPower) + "earth damage)") };
                    case 1:
                        Stamina -= 15;
                        return new List<StatPackage>() { new StatPackage(DmgType.Earth, Strength*1/2 + MagicPower, "Small Slime attacks you with a slimy substance it is made of! (" + (Strength * 1 / 2 + MagicPower) + "earth damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, Strength*1/2, "Small Slime attacks you with its head! (" + (Strength*1/2) + "other damage)") };
                }
            }
            else if (Stamina > 0 && Stamina < 25)
            {
                int chance = Index.RNG(0, 1);
                switch (chance)
                {
                    case 0:
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Earth, 10 + Strength * 1 / 2, "Small Slime stomps the ground creating a small earthquake! (" + (10 + Strength * 1 / 2) + "earth damage)") };
                    default:
                        Stamina -= 5;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, Strength, "Small Slime jumps on you trying to crush you! (" + (Strength) + "crush damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Small Slime is out of stamina and cannot attack anymore!") };
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

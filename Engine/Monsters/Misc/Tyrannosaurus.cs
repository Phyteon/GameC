using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Tyrannosaurus : Monster
    {
        public Tyrannosaurus()
        {
            Health = 180;
            Strength = 50;
            Armor = 40;
            Precision = 50;
            MagicPower = 20;
            Stamina = 120;
            XPValue = 150;
            Name = "monster1120";
            BattleGreetings = "I'm a powerful mutant Tyrannosaurus! Consider if it's worth attacking me. Your 1st attack just make me healthier.";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Health > 150)
            {
                Stamina -= 30;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Cut, 40, "Tyrannosaurus uses poisoned Spines! (" + 40 + " cut damage)"),
                    new StatPackage(DmgType.Poison, 20, "Poison burns in your veins (20 poison damage)")
                };
            }

            if (Health > 0 && Health <= 150)
            {
                Stamina -= 20;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Cut, 15, "Tyrannosaurus uses his fangs! (" + 15 + " cut damage)")
                };
            }

            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Tyrannosaurus has no energy to attack anymore!")
                };
            }
        }

        int playerAttack = 0;

        public override void React(List<StatPackage> packs) 
        {
            playerAttack++;

            if (playerAttack >= 2)
            {
                foreach (StatPackage pack in packs) 
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
            }

            else
            {
                if (packs != null) packs[0].CustomText += "\n Tyrannosaurus gains strength from your attack!";
                foreach (StatPackage pack in packs) 
                {
                    Health += pack.HealthDmg;
                }
            }
        }
    }
}

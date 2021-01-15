using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Eagle : Monster
    {
        public Eagle()
        {
            Health = 120;
            Strength = 10;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 150;
            XPValue = 90;
            Name = "monster1100";
            BattleGreetings = "You stole my egg, this is a revenge!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina >= 100)
            {
                Stamina -= 25;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 20 + Strength, "Eagle scratches you with claws (" + (20 + Strength) + " cut damage)") };
            }
            if (Stamina > 50 && Stamina < 100)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Eagle pecks you (" + (10 + Strength) + " cut damage)") };
            }
            if (Stamina > 0 && Stamina <= 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength, "Eagle flies and hits you with wing (" + (Strength) + " cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Eagle has no energy to attack anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
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



        
    }
}

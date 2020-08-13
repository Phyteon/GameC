using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class AnubisGuard : Monster
    {
        public AnubisGuard(int anubisLevel)
        {
            Health = 50 + 10 * anubisLevel;
            Strength = 30;
            Armor = 30;
            Precision = 30;
            MagicPower = 60;
            Stamina = 60 + 5 * anubisLevel;
            XPValue = 60 + 5 * anubisLevel;
            Name = "monster0820";
            BattleGreetings = " I am here in the name of The Greatest Anubis!" + " \n" + " Do you have any bandages? Beacuse I`m gonna turn you into a mummy!!!";

        }

        private int reactNumber = 0;
        public override void React(List<StatPackage> packs) // receive the result of your opponent's action
        {
            foreach (StatPackage pack in packs) //if opponent uses magic (water,air,earth,fire) attack, AnubisGuard Strength is increasing.
            {
                if (pack.DamageType == DmgType.water || pack.DamageType == DmgType.air || pack.DamageType == DmgType.earth || pack.DamageType == DmgType.fire) 
                {
                    reactNumber = 1;
                    Strength += 5;
                }
                else reactNumber = 0;
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0 && reactNumber==1) //if opponent uses magic (water,air,earth,fire) attack, Anubis Guard is using his magic attack.
            {
                Stamina -= 10;
                MagicPower -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.fire, MagicPower, "YOU ATTACKED ANUBIS USING MAGIC. Anubis Guard uses his magic: The Pharaoh Curse! (" + (MagicPower) + " fire damage)") };
            }
            else if (Stamina>0) //if opponent uses unmagical attack, Anubis Guard sis using strenght attack.
            {
                Stamina -= 10;
                Strength -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.stab, Strength, " Anubis Guard uses The Pyramid Attack! (" + (Strength) + " Curse damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Anubis Guard has no energy to attack anymore!") };
            }
        }
    }
}

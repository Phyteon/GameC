using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class IceHound : Monster
    {
        public IceHound()
        {
            Health = 160;
            Strength = 40;
            Armor = 60;
            Precision = 80;
            MagicPower = 50;
            Stamina = 220;
            XPValue = 140;
            Name = "monster0014";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            return new List<StatPackage>() { new StatPackage(DmgType.Cut, 30+strength, "Ice Hound bites you. (" + (30+strength) + " cut damage)") };
        }    
        public override void React(List<StatPackage> packs)
        {
            int iceBlock = Index.RNG(0, 10); //30% chance to block some of incomming damage
            if(iceBlock < 3)
            {
                foreach (StatPackage pack in packs)
                {
                    int damgeReduction = 100 / MagicPower;
                    Health -= pack.HealthDmg / damgeReduction;
                    Strength -= pack.StrengthDmg / damgeReduction;
                    Armor -= pack.ArmorDmg / damgeReduction;
                    Precision -= pack.PrecisionDmg / damgeReduction;
                    MagicPower -= pack.MagicPowerDmg / damgeReduction;
                }
            }
            else
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
}

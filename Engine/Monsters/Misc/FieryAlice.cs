using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class FieryAlice : Monster
    {
        public int time;
        public FieryAlice(int alicelevel) 
        {
            Health = 100;
            Strength = 20;
            Armor = 0;
            Precision = 40;
            MagicPower = 10;
            Stamina = 45;
            XPValue = 30;
            Name = "monster1360";
            BattleGreetings = "Hi! I'm FieryAlice and I will destroy you with fire !"; 
            time = 80; 
        }
        public override List<StatPackage> BattleMove() 
        {
            if (time >= 20)
            {
                time -= 20;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Fire, 10 + MagicPower, "FieryAlice breathed fire! ("+ (10 + MagicPower) +" damage)")
                }; 
            }
            else
            {
                return new List<StatPackage>() 
                { 
                    new StatPackage(DmgType.Other, 0, "FieryAlice temperature is too low to damage you!") 
                };
            }
        }

        int numberOfAttack = 0;
        public override void React(List<StatPackage> packs) 
        {
            numberOfAttack++;
            if (numberOfAttack%2==0) 
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Precision -= pack.PrecisionDmg;
                }
            }
            else
            {
                foreach (StatPackage pack in packs)
                {
                    pack.CustomText += "\n FieryAlice is able to dodge your attack!";
                }
            }
        }
    }
}

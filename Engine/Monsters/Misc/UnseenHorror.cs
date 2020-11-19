using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class UnseenHorror: Monster
    {
        public UnseenHorror(int unseenHorrorLevel)
        {
            Health = 100 + 5 * unseenHorrorLevel;
            Strength = 10 + unseenHorrorLevel;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 100;
            XPValue = 40 + unseenHorrorLevel;
            Name = "monster1280";
            BattleGreetings = "GHARGHGAHGAHRGHA"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina >= 80)
            {
                Stamina -= 10;
                return new List<StatPackage>()
                { 
                    new StatPackage(DmgType.Poison, 10 + Strength, "Unseen horror attacks with his void powers! ("+ (10 + Strength) +" poison damage)"),
                };
            }
            else if (Stamina < 80 && Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Poison, 20 + Strength, "Unseen horror is angrier and attacks with more powerful void powers! (" + (20 + Strength) + " poison damage)"),
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Unseen horror has no energy to attack anymore!") };
            }
        }
    }
}

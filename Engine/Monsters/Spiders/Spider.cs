using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Spider : Monster
    {
        public Spider(int spiderLevel)
        {
            Health = 50 + 4 * spiderLevel;
            Strength = 15 + spiderLevel;
            Armor = 5;
            Precision = 60;
            MagicPower = 0;
            Stamina = 70;
            XPValue = 35 + spiderLevel;
            Name = "monster1042";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 15 + Strength, "Spider uses strong Bite! (" + (5 + Strength) + " cut damage)") };
            }

            if (Stamina > 20 && Stamina <= 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Spider uses its Sting! (" + (5 + Strength) + " cut damage)") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Spider uses weak Bite! (" + (5 + Strength) + " cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Spider has no energy to attack anymore!") };
            }
        }
    }
}

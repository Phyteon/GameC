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
        public Spider()
        {
            Health = 50;
            Strength = 15;
            Armor = 5;
            Precision = 60;
            MagicPower = 0;
            Stamina = 70;
            XPValue = 35;
            Name = "monster0003";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 15 + Strength, "Spider uses Bite! (" + (15 + Strength) + " cut damage)") };
            }

            if (Stamina > 20 && Stamina <= 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Spider uses Sting! (" + (5 + Strength) + " cut damage)") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Spider uses Bite! (" + (5 + Strength) + " cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Spider has no energy to attack anymore!") };
            }
        }
    }
}

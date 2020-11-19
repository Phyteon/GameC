using Game.Engine;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class EarthBat: Monster
    {
        public EarthBat(int batLevel)
        {
            Health = 30 + 5 * batLevel;
            Strength = 5 + batLevel;
            Armor = 10;
            Precision = 70;
            MagicPower = 20 + batLevel;
            Stamina = 120;
            XPValue = 50 + batLevel;
            Name = "monster1305";
            BattleGreetings = "It seems you need to experience the power of earth!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 16)
            {
                Stamina -= 15;
                return new List<StatPackage>() { new StatPackage(DmgType.Earth, 15 + MagicPower, "Bat uses Rock Wrecker! (" + (15 + MagicPower) + " earth damage)") };

            }
            else if (Stamina < 16 && Stamina > 0)
            {
                Stamina = -15;
                return new List<StatPackage>() { new StatPackage(DmgType.Earth, 40 + MagicPower, "Bat uses Earthquake (" + (40 + MagicPower) + " earth damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Bat has no energy to attack anymore!") };
            }
        }


    }
}

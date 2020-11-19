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
    class AirBat : Monster
    {
        public AirBat(int batLevel)
        {
            Health = 30 + 5 * batLevel;
            Strength = 5 + batLevel;
            Armor = 10;
            Precision = 70;
            MagicPower = 20 + batLevel;
            Stamina = 120;
            XPValue = 50 + batLevel;
            Name = "monster1304";
            BattleGreetings = "It seems you need to experience the power of wind!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 16)
            {
                Stamina -= 15;
                return new List<StatPackage>() { new StatPackage(DmgType.Air, 15 + MagicPower, "Bat uses Wind Attack! (" + (15 + MagicPower) + " air damage)") };

            }
            else if (Stamina < 16 && Stamina > 0)
            {
                Stamina = -15;
                return new List<StatPackage>() { new StatPackage(DmgType.Air, 40 + MagicPower, "Bat uses Hurricane! (" + (40 + MagicPower) + " air damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Bat has no energy to attack anymore!") };
            }
        }



    }
}

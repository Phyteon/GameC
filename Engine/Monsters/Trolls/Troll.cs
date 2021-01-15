using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Built_In
{
    [Serializable]
    class Troll : Monster
    {
        public Troll()
        {
            Health = 80;
            Strength = 20;
            Armor = 0; 
            Precision = 10;
            MagicPower = 0;
            Stamina = 110; 
            XPValue = 90;
            Name = "monster1340";
            BattleGreetings = "I'll crush you!"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina >=100)
            {
                Stamina -= 50;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush, 8, "I'm crushing you! (" + (12) + " crush damage)") };
            }

            else if (Stamina > 20 && Stamina < 100)
            {
                Stamina -= 40;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush,  5, "I'm crushing you! (" + (5) + " crush damage)") };
            }

            else if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush, 2, "I'm crushing you! (" + (2) + " crush damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Troll is exhausted!") };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Phoenix:Monster
    {
        private int hits = 0;
        public Phoenix(int PhoenixLevel)
        {
            Health = 60 + 7 * PhoenixLevel;
            Strength = 20 + 2 * PhoenixLevel;
            Armor = 0;
            Precision = 70;
            MagicPower = 30 + 2 * PhoenixLevel;
            Stamina = 100;
            XPValue = 40 + 3 * PhoenixLevel;
            Name = "monster0180";
            BattleGreetings = "I was born of ashes!"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 20;
                hits += 1;
                if(hits%2==0) return new List<StatPackage>() { new StatPackage(DmgType.cut, 10 + Strength, "Phoenix attacks with his claws! (" + (10 + Strength) + " incised damage)") };
                else return new List<StatPackage>() { new StatPackage(DmgType.fire, 10 + MagicPower, "Phoenix uses Fire! (" + (10 + MagicPower) + " fire damage)") };

            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Phoenix has no energy to attack anymore!") };
            }
        }
    }
}

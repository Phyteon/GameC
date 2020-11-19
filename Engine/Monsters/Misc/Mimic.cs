using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class Mimic:Monster
    {
        public Mimic(int mimicLevel)
        {
          
            Health = 50 + 5 * mimicLevel;
            Strength = 5 + mimicLevel;
            Armor = 8;
            Precision = 50;
            MagicPower = 0;
            Stamina = 60;
            XPValue = 100 + 2 * mimicLevel;
            Name = "monster0581";
            BattleGreetings = "You approach the shop, but the shape changes into something weird..."; 
        }

        public override List<StatPackage> BattleMove()
        {
            if (health > 0.5 * Health) return new List<StatPackage>() { new StatPackage(DmgType.Cut, 45 + strength, "The mimic attacks dealing " + (45+strength) + " damage") };
            else return new List<StatPackage>() { new StatPackage(DmgType.Cut, 45 + 2 * strength, "The mimic attacks ferociously" + (45 + 2*strength) + " damage") };
        }
    }
}

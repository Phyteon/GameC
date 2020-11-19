using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Hydra1 : Monster
    {
        public Hydra1(int hydraLevel)
        {
                Health = 100 + 1 * hydraLevel;
                Strength = 10 + 11 * hydraLevel;
                Armor = 10;
                Precision = 10;
                MagicPower = 0;
                Stamina = 1000;
                XPValue = 100 + hydraLevel;
            Name = "monster1284";
            BattleGreetings = "Looks like I am the chosen one. Prepare to die";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Hydra uses POWERFUL Bite! (" + (10 + Strength) + " cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Hydra has no energy to attack anymore!") };
            }
        }
    }
}

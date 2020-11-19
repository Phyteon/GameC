using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Hydra2 : Monster
    {
        public Hydra2(int hydraLevel)
        {
            Health = 22 + +2 * 2 * 2 * 2 + 2 * hydraLevel;
            Strength = 22 + 2 * 2 * hydraLevel;
            Armor = 20;
            Precision = 20;
            MagicPower = 0;
            Stamina = 200;
            XPValue = 20 + hydraLevel;
            Name = "monster1283";
            BattleGreetings = "Tragedy always comes in pairs!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 2 + Strength, "Hydra uses Bite! (" + (2 + Strength) + " cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Hydra has no energy to attack anymore!") };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Hydra3 : Monster
    {
        public Hydra3(int hydraLevel)
        {
            Health = 30 + 3 * 3 + 3 * hydraLevel;
            Strength = 3 + 3 * hydraLevel;
            Armor = 33;
            Precision = 33;
            MagicPower = 0;
            Stamina = 300;
            XPValue = 30 + hydraLevel;
            Name = "monster1282";
            BattleGreetings = "What have you done to our brother! We will kick your ass for three...";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 3 + Strength, "Hydra uses Bite! (" + (3 + Strength) + " cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Hydra has no energy to attack anymore!") };
            }
        }
    }
}

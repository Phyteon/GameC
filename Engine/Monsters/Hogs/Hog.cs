using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Hog : Monster
    {
        public Hog(int hogLevel)
        {
            Health = 50 + 10 * hogLevel;
            Strength = 10 + 2 * hogLevel;
            Armor = 5;
            Precision = 30;
            MagicPower = 0;
            Stamina = 40;
            XPValue = 40 + 2 * hogLevel;
            Name = "monster1420";
            BattleGreetings = "Oink!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 12 + Strength, "Hog Charges! (" + (12 + Strength) + " cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Hog is out of Stamina!") };
            }
        }
    }
}

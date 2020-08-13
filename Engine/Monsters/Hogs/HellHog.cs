using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class HellHog : Monster
    {
        public HellHog(int hellHogLevel)
        {
            Health = 60 + 10 * hellHogLevel;
            Strength = 15 + 3 * hellHogLevel;
            Armor = 8;
            Precision = 35;
            MagicPower = 1 + hellHogLevel;
            Stamina = 50;
            XPValue = 80 + 4 * hellHogLevel;
            Name = "monster1421";
            BattleGreetings = "Hellish Oink!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.stab, 11 + Strength, "Hell Hog Charges! (" + (11 + Strength) + " stab damage)"),
                    new StatPackage(DmgType.fire, 5 * MagicPower, "Fire surrounding the creature burns you! (" + (5 * MagicPower) + " fire damage)")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Hell Hog is out of Stamina!") };
            }
        }
    }
}

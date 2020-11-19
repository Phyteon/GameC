using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Tarantula : Monster
    {
        public Tarantula(int spiderLevel)
        {
            Health = 75 + 4 * spiderLevel;
            Strength = 30 + spiderLevel;
            Armor = 10;
            Precision = 120;
            MagicPower = 50 + spiderLevel;
            Stamina = 100;
            XPValue = 70 + spiderLevel;
            Name = "monster1043";
            BattleGreetings = "I can smell you, my little fly!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Health > 40)
            {
                if (Stamina > 70)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 20 + Strength, "Tarantula Charges Forward! (" + (20 + Strength) + " cut damage)") };
                }

                if (Stamina > 0 && Stamina <= 70)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 15 + MagicPower, "Tarantula's poison Digests you from the inside! (" + (15 + MagicPower) + " poison damage)") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Tarantula has no energy to attack anymore!") };
                }
            }
            else
            {
                if (Stamina > 0)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Tarantula uses Bite! (" + (10 + Strength) + " cut damage)") };
                }

                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Tarantula has no energy to attack anymore!") };
                }
            }
        }
    }
}

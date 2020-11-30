using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Bat : Monster
    {
        public Bat()
        {
            Health = 20;
            Strength = 3;
            Armor = 0;
            Precision = 50;
            Stamina = 100;
            XPValue = 15;
            Name = "monster0005";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 5;
                int chance = Index.RNG(0, 10);
                switch (chance)
                {
                    case 0:
                        //Bat accidentally hits you with his wing
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 2 + Strength, "Bat flies and accidentally hits you with wing (" + (2 + Strength) + " damage)") };
                    default:
                        //Bat just flies, he can't even bite a man
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Bat flies and can't hit you (0 damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Bat has no energy to fly anymore!") };
            }
        }
    }
}

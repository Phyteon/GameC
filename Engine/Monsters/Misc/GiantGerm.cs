using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class GiantGerm: Monster
    {
        public GiantGerm(int germLevel)
        {
            Health = 50 + 5 * germLevel;
            Strength = 10 + germLevel;
            Armor = 0;
            Precision = 10;
            MagicPower = 0;
            Stamina = 10;
            XPValue = 20 + germLevel;
            Name = "monster0481";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 3;
                // germ is poisonous 
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.poison, 5 + Strength, "Germ makes you ill! (" + (Strength) + " poison damage)")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Germ has no energy to attack anymore!") };
            }
        }
    }
}

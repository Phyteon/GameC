using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Hydra4: Monster
    {
        public Hydra4(int hydraLevel)
        {
            Health = 40 + 4 * hydraLevel;
            Strength = 4 + 4* hydraLevel;
            Armor = 0;
            Precision = 40;
            MagicPower = 0;
            Stamina = 400;
            XPValue = 40 + hydraLevel;
            Name = "monster1281";
            BattleGreetings = "Are you challenging us? Thats a 4head...";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.stab, 4 + Strength, "Hydra uses Bite! (" + (4 + Strength) + " stab damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Hydra has no energy to attack anymore!") };
            }
        }
    }
}

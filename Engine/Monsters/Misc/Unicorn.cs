using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Unicorn:Monster
    {
        public Unicorn(int unicornLevel)
        {
            Health = 110 + 2 * unicornLevel;
            Strength = 30 + 2 * unicornLevel;
            Armor = 0;
            Precision = 50;
            MagicPower = 10 * unicornLevel;
            Stamina = 80;
            XPValue = 70 + 5 * unicornLevel;
            Name = "monster0181";
            BattleGreetings = "Rainbow!"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 30;
                if (Index.RNG(0, 3) == 0) return new List<StatPackage>() { new StatPackage(DmgType.stab, 15 + Strength, "Unicorn stabs you with its horn! (" + (5 + Strength) + " stab damage)") };
                else return new List<StatPackage>() { new StatPackage(DmgType.air, MagicPower * 2, "Unicorn creates rainbow! (" + (MagicPower * 2) + " air damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Unicorn has no energy to attack anymore!") };
            }
        }
    }
}

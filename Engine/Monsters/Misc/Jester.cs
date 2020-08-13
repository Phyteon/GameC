using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Jester : Monster
    {
        public Jester(int jesterLevel)
        {
            Health = 250 + jesterLevel;
            Strength = 10 + jesterLevel;
            Armor = 10 + jesterLevel;
            Precision = 50 + jesterLevel;
            MagicPower = 0;
            Stamina = 60;
            XPValue = 50 + jesterLevel;
            Name = "monster1140";
            BattleGreetings = "The joke's on you";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.stab, Strength + (Precision/10), "Jester used Jester's Rod! (" + (Strength + (Precision / 10)) + " stab damage)") };
            }
            else
            {
                int test =Index.RNG(0, 101);
                if (test < 11)
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.fire, 500, "Jester has exploded!") }; 
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Jester has no energy to attack anymore!") };
                }
            }
        }
    }
}
